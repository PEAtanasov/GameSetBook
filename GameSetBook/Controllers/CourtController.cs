using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using GameSetBook.Common.Enums;
using GameSetBook.Common.Enums.EnumExtensions;
using GameSetBook.Core.Contracts;
using GameSetBook.Core.Models.Court;
using static GameSetBook.Common.UserConstants;
using System.Security.Claims;

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

            ViewBag.Surfaces = GetSurfaces(); ;

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
                ViewBag.Surfaces = ViewBag.Surfaces = GetSurfaces();

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

            return RedirectToAction("Index", "Club");
        }

        [HttpGet]
        [Authorize(Roles = ClubOwnerRole)]
        public async Task<IActionResult> Edit(int id)
        {
            CourtEditFormModel model;
            try
            {
                model = await courtService.GetCourtEditFormModelAsync(id);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return BadRequest();
            }

            if (model.ClubOwnerId != User.Id())
            {
                return Unauthorized();
            }

            ViewBag.Surfaces = GetSurfaces();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = ClubOwnerRole)]
        public async Task<IActionResult> Edit(CourtEditFormModel model)
        {
            if (model.ClubOwnerId != User.Id())
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Surfaces = GetSurfaces();

                return View(model);
            }

            try
            {
                await courtService.Edit(model);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return BadRequest();
            }

            return RedirectToAction("MyClub", "Club", new { id = model.ClubId });
        }

        [HttpGet]
        public async Task<IActionResult> Schedule(int id, DateTime? date)
        {
            int clubId = id;

            ViewData["ClubId"] = clubId;

            if (!await clubService.ClubExsitAsync(clubId))
            {
                return BadRequest();
            }
            
            DateTime currentDate = date ?? DateTime.Now;

            if (currentDate.Date< DateTime.Now.Date)
            {
                currentDate = DateTime.Now;
            }

            var model = await courtService.GetAllCourtsScheduleAsync(clubId, currentDate);

            ViewData["CurrentDate"] = currentDate;

            ViewData["ClubInfo"] = await clubService.GetClubIfnoAsync(clubId);

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = ClubOwnerRole)]
        public async Task<IActionResult> MySchedule(int id, DateTime? date)
        {
            int clubId = id;

            ViewData["ClubId"] = clubId;

            if (!await clubService.ClubExsitAsync(clubId))
            {
                return BadRequest();
            }

            if (!await clubService.IsTheOwnerOfTheClub(clubId, User.Id()))
            {
                return Unauthorized();
            }

            DateTime currentDate = date ?? DateTime.Now;

            var model = await courtService.GetAllCourtsScheduleAsync(clubId, currentDate);

            ViewData["CurrentDate"] = currentDate;

            ViewData["ClubInfo"] = await clubService.GetClubIfnoAsync(clubId);

            return View(model);
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
