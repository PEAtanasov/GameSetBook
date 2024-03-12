using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using GameSetBook.Core.Models;
using System.Security.Claims;
using GameSetBook.Core.Services;
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
            
            var model = await clubService.GetAllClubsReadOnlyAsync();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
