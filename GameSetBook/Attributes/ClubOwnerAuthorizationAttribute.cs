using GameSetBook.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using System.Threading.Tasks;

public class ClubOwnerAuthorizationAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
{
    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        IClubService? clubService = context.HttpContext.RequestServices.GetService<IClubService>();

        if (clubService == null)
        {
            context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            return;
        }

        var clubId = context.RouteData.Values["id"];
        var userId = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (clubId == null || userId == null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        int parsedClubId = int.Parse(clubId.ToString());

        if (!await clubService.ClubExsitAsync(parsedClubId))
        {
            context.Result = new BadRequestResult();
            return;
        }

        if (!await clubService.IsClubAprooved(parsedClubId))
        {
            context.Result = new BadRequestResult();
            return;
        }

        if (!await clubService.IsTheOwnerOfTheClubAsync(parsedClubId, userId))
        {
            context.Result = new ForbidResult();
            return;
        }
    }
}
