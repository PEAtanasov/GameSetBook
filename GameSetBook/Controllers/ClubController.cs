using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

using GameSetBook.Core.Contracts;
using GameSetBook.Core.Models.Club;
using static GameSetBook.Common.ErrorMessageConstants;
using static GameSetBook.Common.UserConstants;
using GameSetBook.Web.Extensions;

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

        [HttpGet]
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
            var model = new ClubFormModel();

            var cities = await clubService.GetAllCitiesAsync();

            ViewBag.Cities = cities.Select(x => new SelectListItem(x.Name, x.Id.ToString()));

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClubFormModel model, IFormFile? clubLogoImage)
        {
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

            var user = await userManager.GetUserAsync(User);

            if (!await roleManager.RoleExistsAsync(ClubOwnerRole))
            {
                await roleManager.CreateAsync(new IdentityRole(ClubOwnerRole));
            }

            if (!await userManager.IsInRoleAsync(user,ClubOwnerRole))
            {
                await userManager.AddToRoleAsync(user, ClubOwnerRole);
            }
  
            var id = await clubService.GetClubByIdByNameAsync(model.Name);

            return RedirectToAction("Create", "Court", new { clubId = id, numberOfCourts = model.NumberOfCourts });
        }

        public async Task<IActionResult> Edit(int clubId)
        {
            return View();
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
