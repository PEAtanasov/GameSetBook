using GameSetBook.Core.Contracts.Admin;
using Microsoft.AspNetCore.Mvc;

namespace GameSetBook.Web.Areas.Admin.Components
{
    public class ClubMenuComponent : ViewComponent
    {
        private readonly IClubServiceAdmin clubService;

        public ClubMenuComponent(IClubServiceAdmin clubService)
        {
            this.clubService = clubService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int clubId)
        {
            var model = await clubService.GetClubMenuAsync(clubId);

            return await Task.FromResult<IViewComponentResult>(View(model));
        }
    }
}
