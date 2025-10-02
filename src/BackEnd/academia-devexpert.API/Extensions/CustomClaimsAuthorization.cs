using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace academia_devexpert.API.Extensions;

public class CustomAuthorization
{
	public static bool ValidarCalimsUsuario(HttpContext httpContext, string claimName, string claimValue)
	{
		if (httpContext.User.Identity == null) throw new InvalidOperationException();

		return
			httpContext.User.Identity.IsAuthenticated &&
			httpContext.User.Claims.Any(c =>
				c.Type == claimName && c.Value.Contains(claimValue)
			);
	}
}

public class ClaimsAuthorizeAttribute : TypeFilterAttribute
{
	public ClaimsAuthorizeAttribute(string claimName, string claimValue) : base(typeof(RequisitoClaimFilter))
	{
		Arguments = [new Claim(claimName, claimValue)];
	}
}

public class RequisitoClaimFilter : IAuthorizationFilter
{
	private readonly Claim _claim;

	public RequisitoClaimFilter(Claim claim)
	{
		_claim = claim;
	}

	public void OnAuthorization(AuthorizationFilterContext context)
	{
		if (context.HttpContext.User.Identity == null) throw new InvalidOperationException();

		if (!context.HttpContext.User.Identity.IsAuthenticated)
		{
			context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
			return;
		}

		if (!CustomAuthorization.ValidarCalimsUsuario(context.HttpContext, _claim.Type, _claim.Value))
		{
			context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
		}
	}
}
