using Microsoft.AspNetCore.Mvc;

namespace GameSetBook.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index() 
        { 
            return View();
        }
    }
}
