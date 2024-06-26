﻿using GameSetBook.Core.Contracts.Admin;
using GameSetBook.Core.Models.Admin.City;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using static GameSetBook.Common.ErrorMessageConstants;

namespace GameSetBook.Web.Areas.Admin.Controllers
{
    public class CityController : BaseController
    {
        private readonly ICityServiceAdmin cityService;
        private readonly ICountryServiceAdmin countryService;

        public CityController(ICityServiceAdmin cityService, ICountryServiceAdmin countryService)
        {
            this.cityService = cityService;
            this.countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await cityService.GetAllCitiesAsync();

            model=model.OrderBy(c=>c.CountryName).ToList();

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (!await cityService.ExistById(id))
            {
                return BadRequest();
            }

            var mdoel = await cityService.GetCityDetailsAsync(id);

            return View(mdoel);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new CityAddAdminFormModel();

            var counties = await countryService.GetAllCountriesAsync();
            ViewBag.Countries = counties.Select(x => new SelectListItem(x.Name, x.Id.ToString()));

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CityAddAdminFormModel model)
        {
            if (await cityService.ExistByNameAsync(model.Name, model.CountryId))
            {
                ModelState.AddModelError(string.Empty, string.Format(CityWithNameExist, model.Name));
            }

            if (!ModelState.IsValid)
            {
                var counties = await countryService.GetAllCountriesAsync();
                ViewBag.Countries = counties.Select(x => new SelectListItem(x.Name, x.Id.ToString()));
                return View(model);
            }

            await cityService.AddAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await cityService.ExistById(id))
            {
                return BadRequest();
            }

            await cityService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
