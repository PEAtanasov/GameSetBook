using GameSetBook.Core.Contracts.Admin;
using GameSetBook.Core.Models.Admin.Review;
using Microsoft.AspNetCore.Mvc;

namespace GameSetBook.Web.Areas.Admin.Controllers
{
    public class ReviewController : BaseController
    {
        private readonly IReviewServiceAdmin reviewService;
        private readonly IClubServiceAdmin clubService;

        public ReviewController(IReviewServiceAdmin reviewService, IClubServiceAdmin clubService)
        {
            this.reviewService = reviewService;
            this.clubService = clubService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AllClubReviews(int clubId)
        {
            if (!await clubService.ExistAsync(clubId))
            {
                return BadRequest();
            }

            ViewData["ClubName"] = await clubService.GetClubNameAsync(clubId);

            var model = await reviewService.AllClubReviewsAsync(clubId);

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (!await reviewService.ExistAsync(id))
            {
                return BadRequest();
            }

            var model = await reviewService.GetDetailsViewModel(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Revise(int id)
        {
            if (!await reviewService.ExistAsync(id))
            {
                return BadRequest();
            }

            var model = await reviewService.GetReviewReviseModelAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Revise(ReviewReviseAdminFormModel model)
        {
            if (!await reviewService.ExistAsync(model.Id))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await reviewService.ReviseAsync(model);

            return RedirectToAction(nameof(Details), new { id = model.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ReviewReviseAdminFormModel model)
        {
            if (!await reviewService.ExistAsync(model.Id))
            {
                return BadRequest();
            }

            await reviewService.HardDeleteAsync(model.Id);

            if (model.ClubId==null)
            {
                return RedirectToAction("Index", "Booking");
            }

            return RedirectToAction(nameof(AllClubReviews), new { model.ClubId });
        }
    }
}
