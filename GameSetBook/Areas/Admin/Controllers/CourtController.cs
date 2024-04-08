using GameSetBook.Common.Enums;
using GameSetBook.Common.Enums.EnumExtensions;
using GameSetBook.Core.Contracts.Admin;
using GameSetBook.Core.Models.Admin.Court;
using GameSetBook.Core.Models.Court;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameSetBook.Web.Areas.Admin.Controllers
{
    public class CourtController : BaseController
    {
        private readonly ICourtServiceAdmin courtService;
        private readonly IClubServiceAdmin clubService;

        public CourtController(ICourtServiceAdmin courtService, IClubServiceAdmin clubService)
        {
            this.courtService = courtService;
            this.clubService = clubService;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add(int clubId, string? returnUrl)
        {
            if (!await clubService.ExistAsync(clubId))
            {
                return BadRequest();
            }

            ViewData["returnUrl"] = returnUrl;

            ViewBag.Surfaces = GetSurfaces();

            var model = new CourtAdminCreateFormModel()
            {
                ClubId = clubId,
                ClubName = await clubService.GetClubNameAsync(clubId)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CourtAdminCreateFormModel model, string? returnUrl)
        {
            if (!await clubService.ExistAsync(model.ClubId))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            await courtService.AddAsync(model);

            if (returnUrl!=null)
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Details", "Club", new {id = model.ClubId});
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id, string? returnUrl)
        {
            if (!await courtService.ExistAsync(id))
            {
                return BadRequest();
            }

            ViewData["returnUrl"] = returnUrl;

            var model = await courtService.GetEditModelAsync(id);

            ViewBag.Surfaces = GetSurfaces();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CourtAdminEditFormModel model, string? returnUrl)
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

            await courtService.EditAsync(model);

            if (returnUrl != null)
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Details", "Club", new { id = model.ClubId });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id, string? returnUrl) 
        {
            if (!await courtService.ExistAsync(id))
            {
                return BadRequest();
            }

            var model = await courtService.GetViewModelForDeleteAsync(id);

            model.ReturnUrl=returnUrl;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CourtAdminViewModel model)
        {
            if (!await courtService.ExistAsync(model.Id))
            {
                return BadRequest();
            }

            await courtService.DeleteAsync(model.Id);

            if (!string.IsNullOrWhiteSpace(model.ReturnUrl))
            {
                return Redirect(model.ReturnUrl);
            }

            return RedirectToAction("Details", "Club", new { id = model.ClubId });
        }

        [HttpGet]
        public async Task<IActionResult> Create(int clubId, int numberOfCourts)
        {
            if(!await clubService.ExistAsync(clubId))
            {
                return BadRequest();
            }

            if (await clubService.IsClubApprovedAsync(clubId))
            {
                return BadRequest();
            }

            if (numberOfCourts <= 0)
            {
                return BadRequest();
            }

            CourtAdminCreateFormModel[] model = new CourtAdminCreateFormModel[numberOfCourts];

            ViewBag.Surfaces = GetSurfaces(); ;

            for (int i = 0; i < numberOfCourts; i++)
            {
                model[i] = new CourtAdminCreateFormModel()
                {
                    ClubId = clubId,
                };
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourtAdminCreateFormModel[] model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Surfaces = GetSurfaces();

                return View(model);
            }

            var clubId = model[0].ClubId;

            if (!await clubService.ExistAsync(clubId))
            {
                return BadRequest();
            }

            //if (await clubService.ClubHasCourts(clubId))
            //{
            //    return BadRequest();
            //}

           

            await courtService.CreateInitialAsync(model);

            return RedirectToAction("Index", "Club");
        }

        private static List<SelectListItem> GetSurfaces()
        {
            return Enum.GetValues(typeof(Surface)).Cast<Surface>().Select(v => new SelectListItem
            {
                Text = v.GetDisplayName(),
                Value = ((int)v).ToString()
            })
            .ToList();
        }
    }
}
