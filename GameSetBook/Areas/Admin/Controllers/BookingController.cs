using GameSetBook.Core.Contracts.Admin;
using GameSetBook.Core.Models.Admin.Booking;
using Microsoft.AspNetCore.Mvc;

namespace GameSetBook.Web.Areas.Admin.Controllers
{
    public class BookingController : BaseController
    {
        private readonly IBookingServiceAdmin bookingService;
        private readonly IClubServiceAdmin clubService;

        public BookingController(IBookingServiceAdmin bookingService, IClubServiceAdmin clubService)
        {
            this.bookingService = bookingService;
            this.clubService = clubService;

        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery]AllBookingsAdminSortingModel model)
        {
            var clubName = string.Empty;
            if (model.ClubId!=null)
            {
                if (!await clubService.ClubExistAsync(model.ClubId.Value))
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
        public async Task<IActionResult> ClubBookings(int clubId)
        {
            if (!await clubService.ClubExistAsync(clubId))
            {
                return BadRequest();
            }

            return View();
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
