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
        [HttpGet]
        public async Task<IActionResult> AllClubReviews([FromQuery]AllReviewAdminSortingModel model)
        {
            if (!await clubService.ExistAsync(model.ClubId))
            {
                return BadRequest();
            }

            model = await reviewService.AllClubReviewsAsync(model);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id, string? returnUrl)
        {
            if (!await reviewService.ExistAsync(id))
            {
                return BadRequest();
            }

            if (!string.IsNullOrWhiteSpace(returnUrl))
            {
                ViewData["returnUrl"] = returnUrl;
            }

            var model = await reviewService.GetDetailsViewModelAsync(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Revise(int id ,string? returnUrl )
        {
            if (!await reviewService.ExistAsync(id))
            {
                return BadRequest();
            }

            if (!string.IsNullOrWhiteSpace(returnUrl))
            {
                ViewData["returnUrl"] = returnUrl;
            }

            var model = await reviewService.GetReviewReviseModelAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Revise(ReviewReviseAdminFormModel model, string? returnUrl)
        {
            if (!await reviewService.ExistAsync(model.Id))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                ViewData["returnUrl"] = returnUrl;
                return View(model);
            }

            await reviewService.ReviseAsync(model);

            if (!string.IsNullOrWhiteSpace(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction(nameof(Details), new { id = model.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ReviewReviseAdminFormModel model, string? returnUrl, AllReviewAdminSortingModel? filters)
        {
            if (!await reviewService.ExistAsync(model.Id))
            {
                return BadRequest();
            }

            await reviewService.HardDeleteAsync(model.Id);

            if (!string.IsNullOrWhiteSpace(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction(nameof(AllClubReviews), filters);
        }
    }
}
