using Microsoft.AspNetCore.Mvc;

using GameSetBook.Core.Contracts;
using GameSetBook.Core.Models.Booking;
using GameSetBook.Web.Extensions;

namespace GameSetBook.Web.Controllers
{
    public class BookingController : BaseController
    {
        private readonly IBookingService bookingService;
        private readonly ICourtService courtService;

        public BookingController(IBookingService bookingService, ICourtService courtService)
        {
            this.bookingService = bookingService;
            this.courtService = courtService;
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

            var model = new BookingCreateFormModel()
            {
                Hour = hour,
                CourtId = courtId,
                BookingDate = bookingDate,
                Price = await courtService.GetPrice(courtId),
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

            if (!ModelState.IsValid)
            {
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
