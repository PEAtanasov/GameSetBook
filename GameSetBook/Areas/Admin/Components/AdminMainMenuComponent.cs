using Microsoft.AspNetCore.Mvc;

namespace GameSetBook.Web.Areas.Admin.Components
{
    public class AdminMainMenuComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult<IViewComponentResult>(View());
        }
    }
}
