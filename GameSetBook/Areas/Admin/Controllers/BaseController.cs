using GameSetBook.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameSetBook.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[Action]/{id?}")]
    [Authorize(Roles = UserConstants.AdminRole)]
    public class BaseController : Controller
    {

    }
}
