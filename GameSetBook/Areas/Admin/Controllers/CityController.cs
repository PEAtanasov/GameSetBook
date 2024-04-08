using Microsoft.AspNetCore.Mvc;

namespace GameSetBook.Web.Areas.Admin.Controllers
{
    public class CityController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
