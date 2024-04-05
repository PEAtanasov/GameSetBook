using GameSetBook.Core.Contracts.Admin;
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

        [HttpPost]
        public async Task<IActionResult> Delete(int id, int clubId)
        {
            if (!await reviewService.ExistAsync(id))
            {
                return BadRequest();
            }

            await reviewService.HardDeleteAsync(id);

            return RedirectToAction(nameof(AllClubReviews), new { clubId });
        }
    }
}
