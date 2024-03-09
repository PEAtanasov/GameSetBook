using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameSetBook.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        
    }
}
