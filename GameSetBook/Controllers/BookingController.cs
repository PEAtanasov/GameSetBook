using Microsoft.AspNetCore.Mvc;

using GameSetBook.Core.Contracts;
using GameSetBook.Core.Models.Booking;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using GameSetBook.Infrastructure.Models.Identity;

using static GameSetBook.Common.UserConstants;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
        public async Task<IActionResult> Index([FromQuery] AllBookingsSortingModel model)
        {
            model = await bookingService.GetBookingSortingServiceModelAsync(model, User.Id());

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Book([FromQuery] BookingScheduleViewModel queryModel)
        {

            int courtId = queryModel.CourtId;

            if (!await courtService.ExistAsync(courtId))
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
                Price = await courtService.GetPriceAsync(courtId),
                ClientName = user.FirstName + " " + user.LastName,
                PhoneNumber = user.PhoneNumber
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Book(BookingCreateFormModel model)
        {
            int courtId = model.CourtId;

            if (!await courtService.ExistAsync(courtId))
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

            var clubId = await bookingService.AddAsync(model);

            return RedirectToAction("Schedule", "Club", new { id = clubId, date = model.BookingDate });
        }

        [HttpPost]
        public async Task<IActionResult> Cancel(int id, AllBookingsSortingModel filters)
        {
            if (!await bookingService.ExistByIdAsync(id))
            {
                return BadRequest();
            }

            if (!await bookingService.IsBookingClientAsync(id,User.Id()))
            {
                return Unauthorized();
            }

            if(!await bookingService.IsCancelableAsync(id))
            {
                return BadRequest();
            }

            await bookingService.DeleteAsync(id);

            return RedirectToAction(nameof(Index),filters);
        }

        [HttpGet]
        [Authorize(Roles = ClubOwnerRole)]
        public async Task<IActionResult> OwnerBook([FromQuery] BookingScheduleViewModel queryModel)
        {
            int courtId = queryModel.CourtId;

            if (!await courtService.ExistAsync(courtId))
            {
                return BadRequest();
            }

            if (!await courtService.IsCourtInClubOfTheOwnerAsync(courtId, User.Id()))
            {
                return Unauthorized();
            }

            int hour = queryModel.Hour;
            var bookingDate = queryModel.BookingDate;

            if (await bookingService.BookingExistAsync(queryModel.BookingDate, queryModel.Hour, queryModel.CourtId))
            {
                return BadRequest();
            }

            var model = new BookingCreateFormModel()
            {
                Hour = hour,
                CourtId = courtId,
                BookingDate = bookingDate,
                Price = await courtService.GetPriceAsync(courtId),
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = ClubOwnerRole)]
        public async Task<IActionResult> OwnerBook(BookingCreateFormModel model)
        {
            int courtId = model.CourtId;

            if (!await courtService.ExistAsync(courtId))
            {
                return BadRequest();
            }

            if (await bookingService.BookingExistAsync(model.BookingDate, model.Hour, model.CourtId))
            {
                return BadRequest();
            }

            if (!await courtService.IsCourtInClubOfTheOwnerAsync(courtId, User.Id()))
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.ClientId = User.Id();
            model.IsBookedByOwnerOrAdmin = true;

            var clubId = await bookingService.AddAsync(model);

            return RedirectToAction("MyClubSchedule", "Club", new { id = clubId, date = model.BookingDate });
        }

        [HttpGet]
        [Authorize(Roles = ClubOwnerRole)]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await bookingService.ExistByIdAsync(id))
            {
                return BadRequest();
            }

            if (!await bookingService.IsClubOwnerAllowedToEditAsync(id, User.Id()))
            {
                return Unauthorized();
            }

            var clubId = await clubService.GetClubIdByOwnerIdAsync(User.Id());

            ViewData["ClubId"] = clubId;

            var model = await bookingService.GetBookingToEditAsync(id);

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = ClubOwnerRole)]
        public async Task<IActionResult> Edit(BookingEditFormModel model)
        {
            if (!await bookingService.ExistByIdAsync(model.Id))
            {
                return BadRequest();
            }

            if (!await bookingService.IsClubOwnerAllowedToEditAsync(model.Id, User.Id()))
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var clubId = await clubService.GetClubIdByOwnerIdAsync(User.Id());

            await bookingService.EditAsync(model);

            return RedirectToAction("MyClubSchedule", "Club", new { id = clubId, date = model.BookingDate });
        }

        [HttpPost]
        [Authorize(Roles = ClubOwnerRole)]
        public async Task<IActionResult> Delete(BookingEditFormModel model)
        {
            if (!await bookingService.ExistByIdAsync(model.Id))
            {
                return BadRequest();
            }

            if (!await bookingService.IsClubOwnerAllowedToEditAsync(model.Id, User.Id()))
            {
                return Unauthorized();
            }

            var clubId = await clubService.GetClubIdByOwnerIdAsync(User.Id());

            await bookingService.DeleteAsync(model.Id);

            return RedirectToAction("MyClubSchedule", "Club", new { id = clubId, date = model.BookingDate });
        }      
    }
}
