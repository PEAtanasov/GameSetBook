using GameSetBook.Common;
using GameSetBook.Core.Contracts;
using GameSetBook.Core.Models.Club;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using static GameSetBook.Common.ErrorMessageConstants;

namespace GameSetBook.Web.Controllers
{
    public class ClubController : BaseController
    {
        private readonly IClubService clubService;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public ClubController(IClubService clubService,
            IWebHostEnvironment webHostEnvironment,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.clubService = clubService;
            this.webHostEnvironment = webHostEnvironment;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var clubs = await clubService.GetAllClubsReadOnlyAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                clubs = clubs.Where(c => c.Name.ToLower().Contains(searchString.ToLower()));
            }

            return View(clubs);
        }

        [HttpGet]
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

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new ClubCreateFormModel();

            var cities = await clubService.GetAllCitiesAsync();

            ViewBag.Cities = cities.Select(x => new SelectListItem(x.Name, x.Id.ToString()));

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClubCreateFormModel model, IFormFile clubLogoImage)
        {
            if (!ModelState.IsValid)
            {
                var cities = await clubService.GetAllCitiesAsync();
                ViewBag.Cities = cities.Select(x => new SelectListItem(x.Name, x.Id.ToString()));
                return View(model);
            }

            string relativePath = string.Empty;

            if (clubLogoImage != null && clubLogoImage.Length > 0)
            {
                if (clubLogoImage.Length > 5242880)
                {
                    TempData["ImageSizeToBig"] = ImageSizeToBig;
                    var cities = await clubService.GetAllCitiesAsync();
                    ViewBag.Cities = cities.Select(x => new SelectListItem(x.Name, x.Id.ToString()));
                    return View(model);
                }

                if (Path.GetExtension(clubLogoImage.FileName).ToLower() != ".jpg"
                    && Path.GetExtension(clubLogoImage.FileName) != ".jpeg"
                    && Path.GetExtension(clubLogoImage.FileName).ToLower() != ".png"
                    && Path.GetExtension(clubLogoImage.FileName).ToLower() != ".gif")
                {
                    TempData["WrongImageFormat"] = WrongImageFormat;
                    var cities = await clubService.GetAllCitiesAsync();
                    ViewBag.Cities = cities.Select(x => new SelectListItem(x.Name, x.Id.ToString()));
                    return View(model);
                }

                string webRootPath = webHostEnvironment.WebRootPath;

                string imagePath = Path.Combine("images", "club_logo");

                string uploadPath = Path.Combine(webRootPath, imagePath);

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                string uniqueFileName = $"{model.Name}_logo{Path.GetExtension(clubLogoImage.FileName)}";

                string filePath = Path.Combine(uploadPath, uniqueFileName);
                relativePath = Path.Combine(imagePath, uniqueFileName).Replace('\\', '/');

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    clubLogoImage.CopyTo(stream);
                }

                model.LogoUrl = relativePath;
            }

            model.ClubOwnerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                await clubService.CreateAsync(model);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, UnknownError);
                return View(model);
            }

            var user = await userManager.GetUserAsync(User);

            if (!await roleManager.RoleExistsAsync(UserConstants.ClubOwnerRole))
            {
                await roleManager.CreateAsync(new IdentityRole(UserConstants.ClubOwnerRole));
            }

            await userManager.AddToRoleAsync(user, UserConstants.ClubOwnerRole);

            var id = await clubService.GetClubByIdByName(model.Name);

            return RedirectToAction("Create", "Court", new { clubId = id, numberOfCourts = model.NumberOfCourts });
        }
    }
}
