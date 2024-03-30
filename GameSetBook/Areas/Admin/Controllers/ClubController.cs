using GameSetBook.Core.Contracts.Admin;
using GameSetBook.Infrastructure.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using static GameSetBook.Common.UserConstants;

namespace GameSetBook.Web.Areas.Admin.Controllers
{
    public class ClubController : BaseController
    {
        private readonly IClubServiceAdmin clubService;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public ClubController(IClubServiceAdmin clubService, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.clubService = clubService;
            this.roleManager = roleManager;
            this.userManager = userManager;

        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PendingClubs()
        {
            var model = await clubService.AllPendingClubsAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Approve(int id)
        {
            if (!await clubService.ClubExistAsync(id))
            {
                return BadRequest();
            }

            var model = await clubService.GetPendingClubDetailsAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveClub(int id)
        {
            if (!await clubService.ClubExistAsync(id))
            {
                return BadRequest();
            }

            if (await clubService.IsClubApproved(id))
            {
                return BadRequest();
            }

            var userId = await clubService.ApproveAsync(id);

            //TODO possibly might need implement the logic for asigning the role via USERSERVICE. Lets keep it like this for now!!!

            var user = await userManager.FindByIdAsync(userId);

            if (user==null)
            {
                return BadRequest();
            }

            var result = await userManager.AddToRoleAsync(user, ClubOwnerRole);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(PendingClubs));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
