using GameSetBook.Core.Contracts.Admin;
using GameSetBook.Core.Models.Admin.Club;
using GameSetBook.Infrastructure.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static GameSetBook.Common.ErrorMessageConstants;
using static GameSetBook.Common.RoleConstants;

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
        private readonly ICourtServiceAdmin courtService;

        public ClubController(IClubServiceAdmin clubService,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            ICityServiceAdmin cityService,
            ICountryServiceAdmin countryService,
            IWebHostEnvironment webHostEnvironment,
            ICourtServiceAdmin courtService)
        {
            this.clubService = clubService;
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.cityService = cityService;
            this.countryService = countryService;
            this.webHostEnvironment = webHostEnvironment;
            this.courtService = courtService;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] AllClubsAdminSortingModel model)
        {
            model = await clubService.GetClubSortingModelAsync(model);

            var cities = await cityService.GetAllCitiesAsync();
            var countries = await countryService.GetAllCountriesAsync();

            if (model.Country != null)
            {
                model.Cities = cities.Where(c => c.CountryName == model.Country).Select(c => c.Name);
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
            if (!await clubService.ExistAsync(id))
            {
                return BadRequest();
            }

            var model = await clubService.GetPendingClubDetailsAsync(id);

            model.ReturnUrl = Url.Action("Approve", "Club", new { id = id });

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveClub(int id)
        {
            if (!await clubService.ExistAsync(id))
            {
                return BadRequest();
            }

            if (await clubService.IsClubApprovedAsync(id))
            {
                return BadRequest();
            }

            var userId = await clubService.ApproveAsync(id);

            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
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
        public async Task<IActionResult> Delete(int id, string clubOwnerId, string? returnUrl)
        {
            if (!await clubService.ExistAsync(id))
            {
                return BadRequest();
            }

            await clubService.DeleteAsync(id);

            var user = await userManager.FindByIdAsync(clubOwnerId);

            if (await userManager.IsInRoleAsync(user, ClubOwnerRole))
            {
                await userManager.RemoveFromRoleAsync(user, ClubOwnerRole);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> HardDelete(int id)
        {
            if (!await clubService.ExistAsync(id))
            {
                return BadRequest();
            }

            var model = await clubService.GetHardDeleteModelAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> HardDelete(ClubHardDeleteAdminServiceModel model)
        {
            if (!await clubService.ExistAsync(model.Id))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await clubService.HardDeleteAsync(model.Id);

            var user = await userManager.FindByIdAsync(model.ClubOwnerId);

            if (await userManager.IsInRoleAsync(user, ClubOwnerRole))
            {
                await userManager.RemoveFromRoleAsync(user, ClubOwnerRole);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id, string? returnUrl)
        {
            if (!await clubService.ExistAsync(id))
            {
                return BadRequest();
            }

            ViewData["returnUrl"] = returnUrl;

            var model = await clubService.GetClubForEditAsync(id);

            var cities = await cityService.GetAllCitiesAsync();

            ViewBag.Cities = cities.Select(x => new SelectListItem(x.Name, x.Id.ToString()));

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClubEditFormModel model, IFormFile? file, string? returnUrl)
        {
            if (!await clubService.ExistAsync(model.Id))
            {
                return BadRequest();
            }

            if (await clubService.ExsitAnotherClubWhitNameAsync(model.Id, model.Name))
            {
                ModelState.AddModelError(string.Empty, string.Format(ClubWithThatNameExist, model.Name));
            }

            if (!ModelState.IsValid)
            {
                var cities = await cityService.GetAllCitiesAsync();
                ViewBag.Cities = cities.Select(x => new SelectListItem(x.Name, x.Id.ToString()));

                return View(model);
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

                    var cities = await cityService.GetAllCitiesAsync();
                    ViewBag.Cities = cities.Select(x => new SelectListItem(x.Name, x.Id.ToString()));

                    return View(model);
                }
            }

            await clubService.EditAsync(model);

            if (returnUrl != null)
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction(nameof(Details), new { id = model.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new ClubAdminCreateFormModel();

            var cities = await cityService.GetAllCitiesAsync();

            ViewBag.Cities = cities.Select(x => new SelectListItem(x.Name, x.Id.ToString()));
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClubAdminCreateFormModel model, IFormFile? file)
        {
            if (await clubService.ExistByNameAsync(model.Name))
            {
                var cities = await cityService.GetAllCitiesAsync();
                ViewBag.Cities = cities.Select(x => new SelectListItem(x.Name, x.Id.ToString()));
                ModelState.AddModelError(string.Empty, string.Format(ClubWithThatNameExist, model.Name));

                return View(model);
            }

            var user = await userManager.FindByEmailAsync(model.ClubOwnerEmail);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, string.Format(UserWithEmailDoesNotExist, model.ClubOwnerEmail));
            }
            else
            {
                if (await userManager.IsInRoleAsync(user, ClubOwnerRole))
                {
                    return BadRequest();
                }

                model.ClubOwnerId = user.Id;
            }

            if (!ModelState.IsValid)
            {
                var cities = await cityService.GetAllCitiesAsync();
                ViewBag.Cities = cities.Select(x => new SelectListItem(x.Name, x.Id.ToString()));

                return View(model);
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

                    var cities = await cityService.GetAllCitiesAsync();
                    ViewBag.Cities = cities.Select(x => new SelectListItem(x.Name, x.Id.ToString()));

                    return View(model);
                }
            }

            await clubService.CreateAsync(model);

            var id = await clubService.GetClubIdByNameAsync(model.Name);

            return RedirectToAction("Create", "Court", new { clubId = id, numberOfCourts = model.NumberOfCourts });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (!await clubService.ExistAsync(id))
            {
                return BadRequest();
            }

            var model = await clubService.GetClubDetailsAsync(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Schedule(ClubScheduleAdminServiceModel model)
        {
            if (!await clubService.ExistAsync(model.Id))
            {
                return BadRequest();
            }

            if (!await clubService.IsClubApprovedAsync(model.Id))
            {
                return BadRequest();
            }

            if (await clubService.IsDeletedAsync(model.Id))
            {
                return BadRequest();
            }

            DateTime currentDate = model.Date ?? DateTime.Now;

            model = await clubService.GetClubScheduleModelAsync(model.Id, currentDate);

            model.Courts = await courtService.GetCourtsScheduleAsync(model.Id, currentDate, model.WorkingHourStart, model.WorkingHourEnd);

            return View(model);
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
