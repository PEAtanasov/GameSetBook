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

        public async Task<IActionResult> All()
        {
            var model = await clubService.GetAllClubsAsync();
            return View(model);
        }
    }
}
