using academia_devexpert.API.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace academia_devexpert.API.Controllers;

[Route("api")]
[ApiController]
public class AutenticacaoController : ControllerBase
{
	private readonly UserManager<IdentityUser> _userManager;
	private readonly SignInManager<IdentityUser> _signInManager;

	public AutenticacaoController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
	{
		_userManager = userManager;
		_signInManager = signInManager;
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

		return Ok(new { message = "Usuário criado com sucesso!" });
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

		return Ok(new { message = "Login bem-sucedido!" });
	}
}
