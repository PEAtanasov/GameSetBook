using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

using GameSetBook.Core.Models.Error;
using GameSetBook.Core.Contracts;

namespace GameSetBook.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClubService clubService;
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger, IClubService clubService)
        {
            this.clubService = clubService;
            this.logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var firstNameClaim = HttpContext.User.FindFirst(ClaimTypes.GivenName)?.Value;
            
            var model = await clubService.GetAllClubsAsync();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode==400)
            {
                return View("Error400");
            }

            if (statusCode == 401)
            {
                return View("Error400");
            }

            return View();
        }
    }
}
