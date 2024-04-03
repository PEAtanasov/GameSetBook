using GameSetBook.Common.Enums;
using GameSetBook.Common.Enums.EnumExtensions;
using GameSetBook.Core.Contracts.Admin;
using GameSetBook.Core.Models.Admin.Court;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameSetBook.Web.Areas.Admin.Controllers
{
    public class CourtController : BaseController
    {
        private readonly ICourtServiceAdmin courtService;

        public CourtController(ICourtServiceAdmin courtService)
        {
            this.courtService = courtService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await courtService.ExistAsync(id))
            {
                return BadRequest();
            }

            var model = await courtService.GetEditModelAsync(id);

            ViewBag.Surfaces = GetSurfaces();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CourtAdminFormModel model)
        {
            if (!await courtService.ExistAsync(model.Id))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Surfaces = GetSurfaces();
                return View(model);
            }

            return RedirectToAction("Index", "Court");
        }

        private static List<SelectListItem> GetSurfaces()
        {
            return Enum.GetValues(typeof(Surface)).Cast<Surface>().Select(v => new SelectListItem
            {
                Text = v.GetDisplayName(),
                Value = ((int)v).ToString()
            }).ToList();
        }
    }
}
