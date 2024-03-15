using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using GameSetBook.Common.Enums;
using GameSetBook.Common.Enums.EnumExtensions;
using GameSetBook.Core.Contracts;
using GameSetBook.Core.Models.Court;

namespace GameSetBook.Web.Controllers
{
    public class CourtController : BaseController
    {
        public readonly ICourtService courtService;
        public readonly IClubService clubService;
        public CourtController(ICourtService courtService, IClubService clubService)
        {
            this.courtService = courtService;
            this.clubService = clubService;
        }

        [HttpGet]
        public async Task<IActionResult> Create(int clubId, int numberOfCourts)
        {
            if (!await clubService.ClubExsitAsync(clubId))
            {
                return BadRequest();
            }

            if (await clubService.IsClubAprooved(clubId))
            {
                return BadRequest();
            }
            
            CourtCreateFormModel[] model = new CourtCreateFormModel[numberOfCourts];

            var surfaceSelectList = Enum.GetValues(typeof(Surface)).Cast<Surface>().Select(v => new SelectListItem
            {
                Text = v.GetDisplayName(),
                Value = ((int)v).ToString()
            }).ToList();
            ViewBag.Surfaces = surfaceSelectList;

            for (int i = 0; i < numberOfCourts; i++)
            {
                model[i] = new CourtCreateFormModel()
                {
                     ClubId = clubId,
                };
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourtCreateFormModel[] model)
        {
            var clubId = model[0].ClubId;

            if (!await clubService.ClubExsitAsync(clubId))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                var surfaceSelectList = Enum.GetValues(typeof(Surface)).Cast<Surface>().Select(v => new SelectListItem
                {
                    Text = v.GetDisplayName(),
                    Value = ((int)v).ToString()
                }).ToList();

                ViewBag.Surfaces = surfaceSelectList;

                return View(model);
            }

            try
            {
                await courtService.CreateInitialAsync(model);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return RedirectToAction("Index","Club");
        }

        public async Task<IActionResult> Edit(int id)
        {

            return View();
        }
    }
}
