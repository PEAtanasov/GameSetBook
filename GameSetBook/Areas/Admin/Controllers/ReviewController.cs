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
            if (!await clubService.ClubExistAsync(clubId))
            {
                return BadRequest();
            }

            ViewData["ClubName"] = await clubService.GetClubNameAsync(clubId);

            var model = await reviewService.AllClubReviews(clubId);

            return View(model);
        }
    }
}
