using GameSetBook.Common.Enums;
using GameSetBook.Common.Enums.EnumExtensions;
using GameSetBook.Core.Contracts;
using GameSetBook.Core.Models.Court;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace GameSetBook.Web.Controllers
{
    public class CourtController : BaseController
    {
        public readonly ICourtService courtService;
        public CourtController(ICourtService courtService)
        {
            this.courtService = courtService;
        }

        [HttpGet]
        public IActionResult Create(int clubId, int numberOfCourts)
        {
            CourtFormModel[] model = new CourtFormModel[numberOfCourts];

            var surfaceSelectList = Enum.GetValues(typeof(Surface)).Cast<Surface>().Select(v => new SelectListItem
            {
                Text = v.GetDisplayName(),
                Value = ((int)v).ToString()
            }).ToList();
            ViewBag.Surfaces = surfaceSelectList;

            for (int i = 0; i < numberOfCourts; i++)
            {
                model[i] = new CourtFormModel()
                {
                     ClubId = clubId,
                };
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CourtFormModel[] model)
        {
            int number = 0;
            foreach (var item in model)
            {
                number = (int)item.Surface;
            }
            return RedirectToAction("Index", "Club");
        }

    }
}
