using GameSetBook.Core.Contracts;
using GameSetBook.Core.Models.Review;
using Microsoft.AspNetCore.Authorization;
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
            if (!await bookingService.ExistByIdAsync(bookingId))
            {
                return BadRequest();
            }

            if (await bookingService.HasReviewAsync(bookingId))
            {
                return BadRequest();
            }

            if (!await bookingService.IsBookingClientAsync(bookingId, User.Id()))
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
            if (!await bookingService.ExistByIdAsync(model.BookingId))
            {
                return BadRequest();
            }

            if (await bookingService.HasReviewAsync(model.BookingId))
            {
                return BadRequest();
            }

            if (!await bookingService.IsBookingClientAsync(model.BookingId, User.Id()))
            {
                return Unauthorized();
            }

            if (!await clubService.ExsitAsync(model.ClubId))
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

            await reviewService.AddReviewAsync(model);

            return RedirectToAction("Index", "Booking");
        }

        [HttpGet]
        public async Task<IActionResult> Revise(int id)
        {
            if (!await reviewService.ExistAsync(id))
            {
                return BadRequest();
            }

            if (!await reviewService.IsTheReviewerAsync(id, User.Id()))
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

            if (!await reviewService.IsTheReviewerAsync(model.Id, User.Id()))
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
        [AllowAnonymous]
        public async Task<IActionResult> AllReviews([FromQuery] AllReviewsSortingServiceModel model)
        {
            if (!await clubService.ExsitAsync(model.ClubId))
            {
                return BadRequest();
            }

            model = await reviewService.GetReviewsSortingModelAsync(model);

            model.ClubInfo = await clubService.GetClubIfnoAsync(model.ClubId);

            return View(model);
        }
    }
}
