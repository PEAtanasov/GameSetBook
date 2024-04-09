using GameSetBook.Core.Contracts.Admin;
using GameSetBook.Core.Models.Admin.Country;
using Microsoft.AspNetCore.Mvc;

using static GameSetBook.Common.ErrorMessageConstants;

namespace GameSetBook.Web.Areas.Admin.Controllers
{
    public class CountryController : BaseController
    {
        private readonly ICountryServiceAdmin countryService;

        public CountryController(ICountryServiceAdmin countryService)
        {
            this.countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await countryService.GetAllCountriesAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new CountryAddAdminFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CountryAddAdminFormModel model)
        {
            if (await countryService.ExistByNameAsync(model.Name))
            {
                ModelState.AddModelError(string.Empty, string.Format(CountryWithNameExist, model.Name));
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await countryService.AddAsync(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
