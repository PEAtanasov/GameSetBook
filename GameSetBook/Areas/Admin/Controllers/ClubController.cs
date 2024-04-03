using GameSetBook.Infrastructure.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System;


using GameSetBook.Core.Contracts.Admin;
using GameSetBook.Core.Models.Admin.Club;
using static GameSetBook.Common.UserConstants;
using static GameSetBook.Common.ErrorMessageConstants;

namespace GameSetBook.Web.Areas.Admin.Controllers
{
    public class ClubController : BaseController
    {
        private readonly IClubServiceAdmin clubService;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICityServiceAdmin cityService;
        private readonly ICountryServiceAdmin countryService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ClubController(IClubServiceAdmin clubService,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            ICityServiceAdmin cityService,
            ICountryServiceAdmin countryService,
        IWebHostEnvironment webHostEnvironment)
        {
            this.clubService = clubService;
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.cityService = cityService;
            this.countryService = countryService;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery]AllClubsAdminSortingModel model)
        {
            model = await clubService.GetClubSortingModel(model);

            var cities = await cityService.GetAllCitiesAsync();
            var countries = await countryService.GetAllCountriesAsync();

            if (model.Country!=null)
            {
                model.Cities = cities.Where(c=>c.CountryName==model.Country).Select(c => c.Name);
            }
            else
            {
                model.Cities = cities.Select(c => c.Name);
            }

            model.Countries = countries.Select(c => c.Name);

            return View(model);
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

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await clubService.ClubExistAsync(id))
            {
                return BadRequest();
            }

            string clubOwnerId = await clubService.DeleteAsync(id);

            var user = await userManager.FindByIdAsync(clubOwnerId);

            if (await userManager.IsInRoleAsync(user,ClubOwnerRole))
            {
                await userManager.RemoveFromRoleAsync(user, ClubOwnerRole);
            }

            return RedirectToAction("index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await clubService.ClubExistIncludingSoftDeletedAsync(id))
            {
                return BadRequest();
            }

            var model = await clubService.GetClubForEditAsync(id);

            var cities = await cityService.GetAllCitiesAsync();

            ViewBag.Cities = cities.Select(x => new SelectListItem(x.Name, x.Id.ToString()));

            return View(model);
        }
            
        [HttpPost]
        public async Task<IActionResult> Edit(ClubEditFormModel model, IFormFile? file)
        {
            if (!await clubService.ClubExistIncludingSoftDeletedAsync(model.Id))
            {
                return BadRequest();
            }

            if (file != null && file.Length > 0)
            {
                try
                {
                    model.LogoUrl = await GetLogoUrlPath(file, model.Name);
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            if (!ModelState.IsValid)
            {
                var cities = await cityService.GetAllCitiesAsync();
                ViewBag.Cities = cities.Select(x => new SelectListItem(x.Name, x.Id.ToString()));

                return View(model);
            }

            await clubService.EditAsync(model);

            return RedirectToAction(nameof(Index));
        }

        private async Task<string> GetLogoUrlPath(IFormFile clubLogoImage, string modelName)
        {
            if (clubLogoImage.Length > 5242880)
            {
                throw new ArgumentException(ImageSizeToBig);
            }

            if (Path.GetExtension(clubLogoImage.FileName).ToLower() != ".jpg"
                   && Path.GetExtension(clubLogoImage.FileName) != ".jpeg"
                   && Path.GetExtension(clubLogoImage.FileName).ToLower() != ".png"
                   && Path.GetExtension(clubLogoImage.FileName).ToLower() != ".gif")
            {
                throw new ArgumentException(WrongImageFormat);
            }

            string webRootPath = webHostEnvironment.WebRootPath;

            string imagePath = Path.Combine("images", "club_logo");

            string uploadPath = Path.Combine(webRootPath, imagePath);

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            string uniqueFileName = $"{modelName.Replace(' ', '_')}_logo{Path.GetExtension(clubLogoImage.FileName)}";

            string filePath = Path.Combine(uploadPath, uniqueFileName);



            var relativePath = Path.Combine(imagePath, uniqueFileName).Replace('\\', '/');

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await clubLogoImage.CopyToAsync(stream);
            }

            return relativePath;
        }
    }
}
