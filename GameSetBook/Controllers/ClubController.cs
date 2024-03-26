using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

using GameSetBook.Core.Contracts;
using GameSetBook.Core.Models.Club;
using static GameSetBook.Common.ErrorMessageConstants;
using static GameSetBook.Common.UserConstants;
using static GameSetBook.Common.ImageSource;
using Microsoft.AspNetCore.Authorization;
using GameSetBook.Infrastructure.Models.Identity;

namespace GameSetBook.Web.Controllers
{
    public class ClubController : BaseController
    {
        private readonly IClubService clubService;
        private readonly ICourtService courtService;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public ClubController(IClubService clubService,
            ICourtService courtService,
            IWebHostEnvironment webHostEnvironment,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.clubService = clubService;
            this.courtService = courtService;
            this.webHostEnvironment = webHostEnvironment;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index([FromQuery] AllClubsSortingModel model)
        {
            var clubs = await clubService.GetClubSortingServiceModelAsync(
                model.City,
                model.SearchTerm,
                model.ClubSorting,
                model.CurrentPage,
                model.ClubsPerPage
                );

            var cities = await clubService.GetAllCitiesAsync();
            model.Cities = cities.Select(c => c.Name);
            model.TotalClubCount = clubs.TotalClubCount;
            model.Clubs = clubs.Clubs;

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {

            if (!await clubService.ClubExsitAsync(id))
            {
                return BadRequest();
            }

            var model = await clubService.GetClubDetailsAndInfoAsync(id);

            return View(model);

        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            if (User.IsInRole(ClubOwnerRole) || await clubService.ClubWithOwnerIdExistAsync(User.Id()))
            {
                TempData["Error"] = UsersAreAllowedToRegisterOnlyOneClub;
                return RedirectToAction(nameof(Index), "Club");
            }
            var model = new ClubFormModel();

            var cities = await clubService.GetAllCitiesAsync();

            ViewBag.Cities = cities.Select(x => new SelectListItem(x.Name, x.Id.ToString()));

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClubFormModel model, IFormFile? file)
        {
            if (User.IsInRole(ClubOwnerRole) || await clubService.ClubWithOwnerIdExistAsync(User.Id()))
            {
                return Unauthorized();
            }

            if (await clubService.ClubExsitByNameAsync(model.Name))
            {
                ModelState.AddModelError(string.Empty, string.Format(ClubWithThatNameExist, model.Name));
            }

            if (!ModelState.IsValid)
            {
                var cities = await clubService.GetAllCitiesAsync();
                ViewBag.Cities = cities.Select(x => new SelectListItem(x.Name, x.Id.ToString()));
                return View(model);
            }

            if (file != null && file.Length > 0)
            {
                try
                {
                    model.LogoUrl = GetLogoUrlPath(file, model.Name);
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);

                    var cities = await clubService.GetAllCitiesAsync();
                    ViewBag.Cities = cities.Select(x => new SelectListItem(x.Name, x.Id.ToString()));

                    return View(model);
                }
            }

            model.ClubOwnerId = User.Id();
            await clubService.CreateAsync(model);

            var id = await clubService.GetClubIdByNameAsync(model.Name);

            return RedirectToAction("Create", "Court", new { clubId = id, numberOfCourts = model.NumberOfCourts });
        }

        [HttpGet]
        [Authorize(Roles = ClubOwnerRole)]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await clubService.ClubExsitAsync(id))
            {
                return BadRequest();
            }
            if (!await clubService.IsTheOwnerOfTheClub(id, User.Id()))
            {
                return Unauthorized();
            }

            var cities = await clubService.GetAllCitiesAsync();

            ViewBag.Cities = cities.Select(x => new SelectListItem(x.Name, x.Id.ToString()));

            var model = await clubService.GetEditFormModelAsync(id);

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = ClubOwnerRole)]
        public async Task<IActionResult> Edit(ClubFormModel model, IFormFile? file)
        {
            if (!await clubService.ClubExsitAsync(model.Id))
            {
                return BadRequest();
            }
            if (!await clubService.IsTheOwnerOfTheClub(model.Id, User.Id()))
            {
                return Unauthorized();
            }

            if (file != null && file.Length > 0)
            {
                try
                {
                    model.LogoUrl = GetLogoUrlPath(file, model.Name);
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);

                    var cities = await clubService.GetAllCitiesAsync();
                    ViewBag.Cities = cities.Select(x => new SelectListItem(x.Name, x.Id.ToString()));

                    return View(model);
                }
            }

            await clubService.EditAsync(model);

            return RedirectToAction(nameof(MyClub), new { id = model.Id });
        }

        [HttpGet]
        [Authorize(Roles = ClubOwnerRole)]
        public async Task<IActionResult> MyClub(int id)
        {
            if (!await clubService.ClubExsitAsync(id))
            {
                return BadRequest();
            }

            if (!await clubService.IsTheOwnerOfTheClub(id, User.Id()))
            {
                return Unauthorized();
            }

            bool isAprooved = await clubService.IsClubAprooved(id);
            ViewData["IsClubAprooved"] = isAprooved;

            var model = new MyClubDetailsServiceModel()
            {
                ClubDetailsAndInfo = await clubService.GetClubDetailsAndInfoAsync(id),
                Courts = await courtService.GetAllCourtsDetails(id),
            };

            return View(model);
        }

        private string GetLogoUrlPath(IFormFile clubLogoImage, string modelName)
        {
            string relativePath = string.Empty;

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
            relativePath = Path.Combine(imagePath, uniqueFileName).Replace('\\', '/');

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                clubLogoImage.CopyTo(stream);
            }

            return relativePath;
        }
    }
}
