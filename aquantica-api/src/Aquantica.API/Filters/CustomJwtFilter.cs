using System.Security.Claims;
using Aquantica.BLL.Interfaces;
using Aquantica.BLL.Services;
using Aquantica.Core.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Aquantica.API.Filters;

public class CustomJwtAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    public CustomJwtAuthorizeAttribute()
    {
    }

    public CustomJwtAuthorizeAttribute(string policy) : base(policy)
    {
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            var user = context.HttpContext.User;
            if (user.Identity?.IsAuthenticated != true)
            {
                context.ModelState.AddModelError("Unauthorized", Resources.Get("YOU_ARE_NOT_AUTHORIZED"));
                context.Result = new UnauthorizedObjectResult(context.ModelState);
            }

            var tokenService = context.HttpContext.RequestServices.GetService<ITokenService>();

            var token = context.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            var principal = tokenService?.GetPrincipalFromToken(token, true);

            if (principal == null)
            {
                context.ModelState.AddModelError("Unauthorized", Resources.Get("YOU_ARE_NOT_AUTHORIZED"));
                context.Result = new UnauthorizedObjectResult(context.ModelState);
            }
            else
            {
                var userId = principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
                if (userId == null)
                {
                    context.ModelState.AddModelError("Unauthorized", Resources.Get("YOU_ARE_NOT_AUTHORIZED"));
                    context.Result = new UnauthorizedObjectResult(context.ModelState);
                }

                var customUserManager = context.HttpContext.RequestServices.GetService<CustomUserManager>();

                if (customUserManager != null)
                    customUserManager.UserId = int.TryParse(userId, out var id) ? id : -1;
            }
        }
        catch (Exception)
        {
            context.ModelState.AddModelError("Unauthorized", Resources.Get("YOU_ARE_NOT_AUTHORIZED"));
            context.Result = new UnauthorizedObjectResult(context.ModelState);
        }
    }
}