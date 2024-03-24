using Microsoft.AspNetCore.Mvc;

using GameSetBook.Core.Contracts;
using GameSetBook.Core.Models.Booking;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using GameSetBook.Infrastructure.Models.Identity;

namespace GameSetBook.Web.Controllers
{
    public class BookingController : BaseController
    {
        private readonly IBookingService bookingService;
        private readonly ICourtService courtService;
        private readonly IClubService clubService;
        private readonly UserManager<ApplicationUser> userManager;

        public BookingController(IBookingService bookingService, ICourtService courtService, IClubService clubService, UserManager<ApplicationUser> userManager)
        {
            this.bookingService = bookingService;
            this.courtService = courtService;
            this.clubService = clubService;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Book([FromQuery] BookingScheduleViewModel queryModel)
        {

            int courtId = queryModel.CourtId;

            if (!await courtService.CourtExist(courtId))
            {
                return BadRequest();
            }

            int hour = queryModel.Hour;
            var bookingDate = queryModel.BookingDate;

            if (!await bookingService.AreDateAndHourValidAsync(queryModel.BookingDate, queryModel.Hour, queryModel.CourtId))
            {
                return BadRequest();
            }

            if (await bookingService.BookingExistAsync(queryModel.BookingDate, queryModel.Hour, queryModel.CourtId))
            {
                return BadRequest();
            }

            var user = await userManager.FindByIdAsync(User.Id());


            var model = new BookingCreateFormModel()
            {
                Hour = hour,
                CourtId = courtId,
                BookingDate = bookingDate,
                Price = await courtService.GetPrice(courtId),
                ClientName = user.FirstName + " " + user.LastName,
                PhoneNumber = user.PhoneNumber
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Book(BookingCreateFormModel model)
        {
            int courtId = model.CourtId;

            if (!await courtService.CourtExist(courtId))
            {
                return BadRequest();
            }

            if (!await bookingService.AreDateAndHourValidAsync(model.BookingDate, model.Hour, model.CourtId))
            {
                return BadRequest();
            }

            if (await bookingService.BookingExistAsync(model.BookingDate, model.Hour, model.CourtId))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                model.PhoneNumber = string.Empty;
                return View(model);
            }

            model.ClientId = User.Id();

            var clubId = await bookingService.AddBookingAsync(model);

            return RedirectToAction("Schedule", "Court", new { id = clubId, date = model.BookingDate});
        }

        public async Task<IActionResult> MyBookings()
        {
            return View();
        }
    }
}
