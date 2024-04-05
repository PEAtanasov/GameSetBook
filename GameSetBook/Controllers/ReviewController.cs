using GameSetBook.Core.Contracts;
using GameSetBook.Core.Models.Review;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GameSetBook.Web.Controllers
{
    public class ReviewController : BaseController
    {
        private readonly IReviewService reviewService;
        private readonly IBookingService bookingService;
        private readonly IClubService clubService;

        public ReviewController(IReviewService reviewService, IBookingService bookingService, IClubService clubService)
        {
            this.reviewService = reviewService;
            this.bookingService = bookingService;
            this.clubService = clubService;
        }

        [HttpGet]
        public async Task<IActionResult> AddReview(int bookingId)
        {
            if (!await bookingService.BookingExistById(bookingId))
            {
                return BadRequest();
            }

            if (await bookingService.BookingHasReview(bookingId))
            {
                return BadRequest();
            }

            if (!await bookingService.IsUserClientOfBooking(User.Id(), bookingId))
            {
                return Unauthorized();
            }

            int? clubId = await clubService.GetClubIdByBookingId(bookingId);

            if (clubId == null)
            {
                return BadRequest();
            }

            if (await clubService.IsTheOwnerOfTheClubAsync(clubId.Value, User.Id()))
            {
                return Unauthorized();
            }

            var model = new ReviewFormModel()
            {
                BookingId = bookingId,
                ReviewerId = User.Id(),
                ClubId = clubId.Value

            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(ReviewFormModel model)
        {
            if (!await bookingService.BookingExistById(model.BookingId))
            {
                return BadRequest();
            }

            if (await bookingService.BookingHasReview(model.BookingId))
            {
                return BadRequest();
            }

            if (!await bookingService.IsUserClientOfBooking(User.Id(), model.BookingId))
            {
                return Unauthorized();
            }

            if (!await clubService.ClubExsitAsync(model.ClubId))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await clubService.IsTheOwnerOfTheClubAsync(model.ClubId, model.ReviewerId))
            {
                return Unauthorized();
            }

            if (model.ReviewerId != User.Id())
            {
                return Unauthorized();
            }

            await reviewService.AddReview(model);

            return RedirectToAction("Index", "Booking");
        }

        [HttpGet]
        public async Task<IActionResult> Revise(int id)
        {
            if (!await reviewService.ExistAsync(id))
            {
                return BadRequest();
            }

            if (!await reviewService.IsTheReviewer(id, User.Id()))
            {
                return Unauthorized();
            }

            var model = await reviewService.GetReviseModelAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Revise(ReviewFormModel model)
        {
            if (!await reviewService.ExistAsync(model.Id))
            {
                return BadRequest();
            }

            if (model.ReviewerId != User.Id())
            {
                return Unauthorized();
            }

            if (!await reviewService.IsTheReviewer(model.Id, User.Id()))
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await reviewService.ReviseAsync(model);

            return RedirectToAction("Index", "Booking");
        }

        [HttpGet]
        public async Task<IActionResult> AllReviews([FromQuery] AllReviewsSortingServiceModel model)
        {
            if (!await clubService.ClubExsitAsync(model.ClubId))
            {
                return BadRequest();
            }

            model = await reviewService.GetReviewsPagingModel(model);

            model.ClubInfo = await clubService.GetClubIfnoAsync(model.ClubId);

            return View(model);
        }
    }
}
