using GameSetBook.Core.Contracts.Admin;
using Microsoft.AspNetCore.Mvc;

namespace GameSetBook.Web.Areas.Admin.Controllers
{
    public class ClubController : BaseController
    {
        private readonly IClubServiceAdmin clubService;

        public ClubController(IClubServiceAdmin clubService)
        {
            this.clubService = clubService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PendingClubs()
        {
            var model = await clubService.AllPendingClubs();

            return View(model);
        }
    }
}
