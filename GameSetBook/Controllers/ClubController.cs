using Microsoft.AspNetCore.Mvc;

using GameSetBook.Core.Contracts;

namespace GameSetBook.Web.Controllers
{
    public class ClubController : BaseController
    {
        private readonly IClubService clubService;

        public ClubController(IClubService clubService)
        {
            this.clubService = clubService;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var clubs = await clubService.GetAllClubsAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                clubs = clubs.Where(c => c.Name.ToLower().Contains(searchString.ToLower()));
            }

            return View(clubs);
        }

        public async Task<IActionResult> Details(int id)
        {
            //if (!await clubService.ClubExsitAsync(id))
            //{
            //    return BadRequest();
            //}

            try
            {
                var model = await clubService.GetClubDetailsAsync(id);
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = ex.Message });

            }
        }
    }
}
