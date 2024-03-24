using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

using GameSetBook.Core.Contracts;
using GameSetBook.Core.Models.Club;
using static GameSetBook.Common.ErrorMessageConstants;
using static GameSetBook.Common.UserConstants;
using Microsoft.AspNetCore.Authorization;
using GameSetBook.Infrastructure.Models.Identity;

namespace GameSetBook.Web.Controllers
{
    public class ClubController : BaseController
    {
        private readonly IClubService clubService;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public ClubController(IClubService clubService,
            IWebHostEnvironment webHostEnvironment,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.clubService = clubService;
            this.webHostEnvironment = webHostEnvironment;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index3(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var clubs = await clubService.GetAllClubsAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                clubs = clubs.Where(c => c.Name.ToLower().Contains(searchString.ToLower()));
            }

            return View(clubs);
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery]AllClubsSortingModel model)
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
        public async Task<IActionResult> Details(int id)
        {

            if (!await clubService.ClubExsitAsync(id))
            {
                return NotFound();
            }

            var model = await clubService.GetClubDetailsAsync(id);

            return View(model);

        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            if (User.IsInRole(ClubOwnerRole) || await clubService.ClubWithOwnerIdExist(User.Id()))
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
        public async Task<IActionResult> Create(ClubFormModel model, IFormFile? clubLogoImage)
        {
            if (User.IsInRole(ClubOwnerRole)|| await clubService.ClubWithOwnerIdExist(User.Id()))
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

            if (clubLogoImage != null && clubLogoImage.Length > 0)
            {
                try
                {
                    model.LogoUrl = GetLogoUrlPath(clubLogoImage,model.Name);
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
        [Authorize(Roles =ClubOwnerRole)]
        public async Task<IActionResult> MyClub(int clubId)
        {
            return View();
        }

        [ClubOwnerAuthorization]
        public async Task<IActionResult> Test(int id)
        {

            var name = User.Identity.Name;

            return RedirectToAction(nameof(Details), new {id});
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
