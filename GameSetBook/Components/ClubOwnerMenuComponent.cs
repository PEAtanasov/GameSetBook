using Microsoft.AspNetCore.Mvc;

namespace GameSetBook.Web.Components
{
    public class ClubOwnerMenuComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult<IViewComponentResult>(View());
        }
    }
}
