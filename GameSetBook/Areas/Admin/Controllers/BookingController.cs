using GameSetBook.Core.Contracts.Admin;
using GameSetBook.Core.Models.Admin.Booking;
using GameSetBook.Core.Models.Booking;
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

        public async Task<IActionResult> Index([FromQuery]AllBookingsAdminSortingModel model)
        {
            model = await bookingService.GetBookingSortingServiceModelAsync(model);

            return View(model);
        }

        public async Task<IActionResult> ClubBookings(int clubId)
        {
            if (!await clubService.ClubExistAsync(clubId))
            {
                return BadRequest();
            }

            return View();
        }
    }
}
