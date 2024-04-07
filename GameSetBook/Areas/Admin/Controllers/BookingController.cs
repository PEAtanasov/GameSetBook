using GameSetBook.Core.Contracts.Admin;
using GameSetBook.Core.Models.Admin.Booking;
using GameSetBook.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GameSetBook.Web.Areas.Admin.Controllers
{
    public class BookingController : BaseController
    {
        private readonly IBookingServiceAdmin bookingService;
        private readonly IClubServiceAdmin clubService;
        private readonly ICourtServiceAdmin courtService;

        public BookingController(IBookingServiceAdmin bookingService, IClubServiceAdmin clubService, ICourtServiceAdmin courtService)
        {
            this.bookingService = bookingService;
            this.clubService = clubService;
            this.courtService = courtService;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery]AllBookingsAdminSortingModel model)
        {
            var clubName = string.Empty;
            if (model.ClubId!=null)
            {
                if (!await clubService.ExistAsync(model.ClubId.Value))
                {
                    return BadRequest();
                }

                clubName= await clubService.GetClubNameAsync(model.ClubId.Value);
            }

            ViewData["ClubName"] = clubName;

            model = await bookingService.GetBookingSortingServiceModelAsync(model);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Book([FromQuery]BookingScheduleAdminServiceModel queryModel, decimal price, int clubId)
        {
            int courtId = queryModel.CourtId;

            if (await clubService.IsDeletedAsync(clubId))
            {
                return BadRequest();
            }

            if (!await clubService.IsClubApprovedAsync(clubId))
            {
                return BadRequest();
            }

            if (!await courtService.ExistAsync(courtId))
            {
                return BadRequest();
            }

            int hour = queryModel.Hour;
            var bookingDate = queryModel.BookingDate;
            var pricePerHour = price;

            if (await bookingService.BookingExistAsync(queryModel.BookingDate, queryModel.Hour, queryModel.CourtId))
            {
                return BadRequest();
            }

            var model = new BookingCreateAdminFormModel()
            {
                Hour = hour,
                CourtId = courtId,
                BookingDate = bookingDate,
                Price = pricePerHour,
                ClubId = clubId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Book(BookingCreateAdminFormModel model)
        {
            if (await clubService.IsDeletedAsync(model.ClubId))
            {
                return BadRequest();
            }

            if (!await clubService.IsClubApprovedAsync(model.ClubId))
            {
                return BadRequest();
            }

            if (!await courtService.ExistAsync(model.CourtId))
            {
                return BadRequest();
            }

            if (await bookingService.BookingExistAsync(model.BookingDate, model.Hour, model.CourtId))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.ClientId = User.Id();
            model.IsBookedByOwnerOrAdmin = true;

            await bookingService.CreateAsync(model);

            return RedirectToAction("Schedule", "Club", new { id = model.ClubId, date = model.BookingDate });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id, string? returnUrl)
        {
            if (!await bookingService.ExistAsync(id))
            {
                return BadRequest();
            }

            if (!string.IsNullOrWhiteSpace(returnUrl))
            {
                ViewData["ReturnUrl"] = returnUrl;
            }

            var model = await bookingService.GetEditModelAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BookingEditAdminFormModel model, string? returnUrl)
        {
            if (!await bookingService.ExistAsync(model.Id))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                if (!string.IsNullOrWhiteSpace(returnUrl))
                {
                    ViewData["ReturnUrl"] = returnUrl;
                }

                return View(model);
            }

            await bookingService.EditAsync(model);

            if (!string.IsNullOrWhiteSpace(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Schedule", "Club", new { id = model.ClubId, date=model.BookingDate }); ;
        }

        [HttpPost]
        public async Task<IActionResult> Cancel(int id, AllBookingsAdminSortingModel filters)
        {
            if (!await bookingService.ExistAsync(id))
            {
                return BadRequest();
            }

            filters = await bookingService.GetBookingSortingServiceModelAsync(filters);

            await bookingService.CancelAsync(id);

            return RedirectToAction("Index", "Booking", filters);
        }
    }
}
