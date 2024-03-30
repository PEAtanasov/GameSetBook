using Microsoft.AspNetCore.Mvc;

namespace GameSetBook.Web.Areas.Admin.Controllers
{
    public class ClubController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
