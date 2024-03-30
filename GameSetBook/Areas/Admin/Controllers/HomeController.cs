using GameSetBook.Core.Contracts.Admin;
using GameSetBook.Core.Models.Admin.Statistics;
using Microsoft.AspNetCore.Mvc;

namespace GameSetBook.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IStatisticService statisticService;

        public HomeController(IStatisticService statisticService)
        {
            this.statisticService = statisticService;
        }

        public async Task<IActionResult> Index()
        {
            var date = DateTime.Now;

            var model = new StatisticsServiceViewModel()
            {
                BookingsStatistics = statisticService.GetBookingStatistics(date),
                ClubStatistics = await statisticService.GetClubsStatistics(),
                CourtStatistics = statisticService.GetCourtStatistics(),
            };

            return View(model);
        }
    }
}
