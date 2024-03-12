using GameSetBook.Common.Enums;
using GameSetBook.Core.Contracts;
using GameSetBook.Core.Models.Court;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Create(int ClubId, int numberOfCourts)
        {
            CourtFormModel[] model = new CourtFormModel[numberOfCourts];

            var surfaceSelectList = EnumHelper.GetEnumSelectList<Surface>();
            

            for (int i = 0; i < numberOfCourts; i++)
            {
                model[i] = new CourtFormModel()
                {
                     ClubId = ClubId,
                };
            }
            return View(model);
        }
    }
}
