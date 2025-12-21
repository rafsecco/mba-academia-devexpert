using System.Security.Claims;

namespace AcademiaDevExpert.WebApp.API.Extensions;

public static class ClaimsPrincipalExtension
{
	public static Guid GetUserId(this ClaimsPrincipal claimsPrincipal)
	{
		var claim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid);
		if (claim is null)
		{
			throw new Exception("ID de usuário não encontrado nas claims");
		}
		return Guid.Parse(claim.Value);
	}
}
