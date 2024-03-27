using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

using GameSetBook.Common.Enums;
using GameSetBook.Common.Enums.EnumExtensions;
using GameSetBook.Core.Contracts;
using GameSetBook.Core.Models.Court;
using static GameSetBook.Common.UserConstants;

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

            if (await clubService.ClubHasCourts(clubId))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Surfaces = GetSurfaces();

                return View(model);
            }

            await courtService.CreateInitialAsync(model);

            return RedirectToAction("Index", "Club");
        }

        [HttpGet]
        [Authorize(Roles = ClubOwnerRole)]
        public async Task<IActionResult> Edit(int id)
        {
            if (! await courtService.CourtExist(id))
            {
                return BadRequest();
            }
            if (!await courtService.IsCourtInOwnerClub(id, User.Id()))
            {
                return Unauthorized();
            }

            var model = await courtService.GetCourtEditFormModelAsync(id);

            ViewBag.Surfaces = GetSurfaces();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = ClubOwnerRole)]
        public async Task<IActionResult> Edit(CourtEditFormModel model)
        {
            if (!await courtService.CourtExist(model.Id))
            {
                return BadRequest();
            }

            if (model.ClubOwnerId != User.Id())
            {
                return Unauthorized();
            }

            if (!await courtService.IsCourtInOwnerClub(model.Id, User.Id()))
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Surfaces = GetSurfaces();

                return View(model);
            }

            await courtService.Edit(model);
            
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
        public async Task<IActionResult> OwnCourtsSchedule(int id, DateTime? date)
        {
            int clubId = id;

            ViewData["ClubId"] = clubId;

            if (!await clubService.ClubExsitAsync(clubId))
            {
                return BadRequest();
            }

            if (!await clubService.IsTheOwnerOfTheClubAsync(clubId, User.Id()))
            {
                return Unauthorized();
            }

            DateTime currentDate = date ?? DateTime.Now;

            var model = await courtService.GetAllCourtsScheduleAsync(clubId, currentDate);

            ViewData["CurrentDate"] = currentDate;

            ViewData["ClubInfo"] = await clubService.GetClubIfnoAsync(clubId);

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = ClubOwnerRole)]
        public async Task<IActionResult> Add()
        {
            var model = new CourtCreateFormModel()
            {
                ClubId = await clubService.GetClubIdByOwnerIdAsync(User.Id())
            };

            ViewBag.Surfaces = GetSurfaces();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = ClubOwnerRole)]
        public async Task<IActionResult> Add(CourtCreateFormModel model)
        {
            if (!await clubService.ClubExsitAsync(model.ClubId))
            {
                return BadRequest();
            }

            if(!await clubService.IsTheOwnerOfTheClubAsync(model.ClubId, User.Id()))
            { 
                return Unauthorized(); 
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Surfaces = GetSurfaces();

                return View(model);
            }

            await courtService.AddCourtAsync(model);

            return RedirectToAction("MyClub","Club", new {id=model.ClubId});
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
