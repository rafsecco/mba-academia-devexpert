using academia_devexpert.API.Extensions;
using academia_devexpert.API.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace academia_devexpert.API.Controllers;

[Route("api")]
[ApiController]
public class AutenticacaoController : ControllerBase
{
	private readonly UserManager<IdentityUser> _userManager;
	private readonly SignInManager<IdentityUser> _signInManager;
	private readonly AppSettings _appSettings;

	public AutenticacaoController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IOptions<AppSettings> appSettings)
	{
		_userManager = userManager;
		_signInManager = signInManager;
		_appSettings = appSettings.Value;
	}

	[HttpPost("nova-conta")]
	public async Task<IActionResult> Registrar(RegisterUserViewModel model)
	{
		if (!ModelState.IsValid) return BadRequest(ModelState);

		var user = new IdentityUser { UserName = model.Email, Email = model.Email, EmailConfirmed = true };
		var result = await _userManager.CreateAsync(user, model.Password);

		if (!result.Succeeded)
		{
			return BadRequest(result.Errors);
		}

		await _signInManager.SignInAsync(user, isPersistent: false);

		return Ok(new
		{
			accessToken = await GerarJwt(model.Email),
			userToken = new
			{
				id = user.Id,
				email = user.Email,
				nomeUsuario = user.UserName
			},
			message = "Usuário criado com sucesso!"
		});
	}

	[HttpPost("entrar")]
	public async Task<IActionResult> Login(LoginUserViewModel model)
	{
		if (!ModelState.IsValid) return BadRequest(ModelState);

		var user = await _userManager.FindByEmailAsync(model.Email);
		if (user == null)
		{
			return Unauthorized("Credenciais inválidas");
		}

		var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

		if (!result.Succeeded)
		{
			return Unauthorized("Credenciais inválidas");
		}

		return Ok(new
		{
			accessToken = await GerarJwt(model.Email),
			userToken = new
			{
				id = user.Id,
				email = user.Email,
				nomeUsuario = user.UserName
			},
			message = "Login bem-sucedido!"
		});
	}

	private async Task<LoginResponseViewModel> GerarJwt(string email)
	{
		var user = await _userManager.FindByEmailAsync(email);
		var userClaims = await _userManager.GetClaimsAsync(user);
		var userRoles = await _userManager.GetRolesAsync(user);

		userClaims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
		userClaims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
		userClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
		userClaims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
		userClaims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));
		foreach (var userRole in userRoles)
		{
			userClaims.Add(new Claim("role", userRole));
		}
		var identityClaims = new ClaimsIdentity();
		identityClaims.AddClaims(userClaims);

		var tokenHandler = new JwtSecurityTokenHandler();
		var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
		var token = tokenHandler.CreateToken(new SecurityTokenDescriptor {
			Issuer = _appSettings.Emissor,
			Audience = _appSettings.ValidoEm,
			Subject = identityClaims,
			Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
			SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
		});

		var encodedToken = tokenHandler.WriteToken(token);

		var response = new LoginResponseViewModel
		{
			AccessToken = encodedToken,
			ExpiresIn = TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
			UserToken = new UserTokenViewModel
			{
				Id = user.Id,
				Email = user.Email,
				Claims = userClaims.Select(c => new ClaimViewModel { Type = c.Type, Value = c.Value })
			}
		};

		return response;
	}

	private static long ToUnixEpochDate(DateTime date)
		=> (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
}
