using GameSetBook.Core.Contracts;
using GameSetBook.Core.Models.Club;
using GameSetBook.Infrastructure.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using static GameSetBook.Common.ErrorMessageConstants;
using static GameSetBook.Common.RoleConstants;

namespace GameSetBook.Web.Controllers
{
    public class ClubController : BaseController
    {
        private readonly IClubService clubService;
        private readonly ICourtService courtService;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ICityService cityService;
        private readonly ICountryService countryService;
        private readonly IReviewService reviewService;

        public ClubController(IClubService clubService,
            ICourtService courtService,
            IWebHostEnvironment webHostEnvironment,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ICityService cityService,
            ICountryService countryService,
            IReviewService reviewService)
        {
            this.clubService = clubService;
            this.courtService = courtService;
            this.webHostEnvironment = webHostEnvironment;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.cityService = cityService;
            this.countryService = countryService;
            this.reviewService = reviewService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index([FromQuery] AllClubsSortingModel model)
        {
            model = await clubService.GetClubSortingServiceModelAsync(model);

            var countries = await countryService.GetAllCountriesAsync();
            var cities = await cityService.GetAllCitiesAsync();

            model.Countries = countries.Select(c => c.Name);

            if (model.Country != null)
            {
                model.Cities = cities.Where(c => c.CountryName == model.Country).Select(c => c.Name);
            }
            else
            {
                model.Cities = cities.Select(c => c.Name);
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {

            if (!await clubService.ExsitAsync(id))
            {
                return NotFound();
            }

            var info = await clubService.GetClubIfnoAsync(id);

            var details = await clubService.GetClubDetailsAsync(id);

            var reviews = await reviewService.GetClubReviewsAsync(id);

            var model = new ClubIfnoDetailsReviewsServiceViewModel()
            {
                ClubId = id,
                ClubDetails = details,
                ClubInfo = info,
                Reviews = reviews.Take(3)
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            if (User.IsInRole(ClubOwnerRole) == false && await clubService.ClubWithOwnerIdExistAsync(User.Id()) == true)
            {
                var clubId = await clubService.GetClubIdByOwnerIdAsync(User.Id());

                if (!await clubService.ClubHasCourtsAsync(clubId))
                {
                    var numberOfCourts = await clubService.NumberOfCourtsAsync(clubId);
                    return RedirectToAction("Create", "Court", new { clubId, numberOfCourts });
                }
            }

            if (User.IsInRole(ClubOwnerRole) || await clubService.ClubWithOwnerIdExistAsync(User.Id()))
            {
                TempData["Error"] = UsersAreAllowedToRegisterOnlyOneClub;
                return RedirectToAction(nameof(Index), "Club");
            }
            var model = new ClubFormModel();

            var cities = await cityService.GetAllCitiesAsync();

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

            if (await clubService.ExsitByNameAsync(model.Name))
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

            model.ClubOwnerId = User.Id();
            await clubService.CreateAsync(model);

            var id = await clubService.GetClubIdByNameAsync(model.Name);

            return RedirectToAction("Create", "Court", new { clubId = id, numberOfCourts = model.NumberOfCourts });
        }

        [HttpGet]
        public async Task<IActionResult> Schedule(int id, DateTime? date)
        {

            ViewData["ClubId"] = id;

            if (!await clubService.ExsitAsync(id))
            {
                return NotFound();
            }

            DateTime currentDate = date ?? DateTime.Now;

            if (currentDate.Date < DateTime.Now.Date)
            {
                currentDate = DateTime.Now;
            }

            var model = await courtService.GetAllCourtsScheduleAsync(id, currentDate);

            ViewData["CurrentDate"] = currentDate;

            ViewData["ClubInfo"] = await clubService.GetClubIfnoAsync(id);

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = ClubOwnerRole)]
        public async Task<IActionResult> MyClubSchedule(int id, DateTime? date)
        {

            ViewData["ClubId"] = id;

            if (!await clubService.ExsitAsync(id))
            {
                return BadRequest();
            }

            if (!await clubService.IsTheOwnerOfTheClubAsync(id, User.Id()))
            {
                return Unauthorized();
            }

            DateTime currentDate = date ?? DateTime.Now;

            var model = await courtService.GetAllCourtsScheduleAsync(id, currentDate);

            ViewData["CurrentDate"] = currentDate;

            ViewData["ClubInfo"] = await clubService.GetClubIfnoAsync(id);

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = ClubOwnerRole)]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await clubService.ExsitAsync(id))
            {
                return BadRequest();
            }
            if (!await clubService.IsTheOwnerOfTheClubAsync(id, User.Id()))
            {
                return Unauthorized();
            }

            var cities = await cityService.GetAllCitiesAsync();

            ViewBag.Cities = cities.Select(x => new SelectListItem(x.Name, x.Id.ToString()));

            var model = await clubService.GetEditFormModelAsync(id);

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = ClubOwnerRole)]
        public async Task<IActionResult> Edit(ClubFormModel model, IFormFile? file)
        {
            if (!await clubService.ExsitAsync(model.Id))
            {
                return BadRequest();
            }
            if (!await clubService.IsTheOwnerOfTheClubAsync(model.Id, User.Id()))
            {
                return Unauthorized();
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

            return RedirectToAction(nameof(MyClub), new { id = model.Id });
        }

        [HttpGet]
        [Authorize(Roles = ClubOwnerRole)]
        public async Task<IActionResult> MyClub(int id)
        {
            if (!await clubService.ExsitAsync(id))
            {
                return BadRequest();
            }

            if (!await clubService.IsTheOwnerOfTheClubAsync(id, User.Id()))
            {
                return Unauthorized();
            }

            var details = await clubService.GetClubDetailsAsync(id);

            var info = await clubService.GetClubIfnoAsync(id);

            var model = new MyClubDetailsServiceModel()
            {
                ClubId = id,
                Details = details,
                Info = info,
                Courts = await courtService.GetAllCourtsDetailsAsync(id),
            };

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
