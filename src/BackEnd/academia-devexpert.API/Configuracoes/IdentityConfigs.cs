using academia_devexpert.API.Data;
using academia_devexpert.API.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace academia_devexpert.API.Configuracoes;

public static class IdentityConfigs
{
	public static void AddIdentityConfiguration(this WebApplicationBuilder builder)
	{
		builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
		{
			options.SignIn.RequireConfirmedEmail = false;
			options.User.RequireUniqueEmail = true;
		})
			.AddEntityFrameworkStores<ApplicationDbContext>()
			.AddErrorDescriber<IdentityMensagensPortugues>()
			.AddDefaultTokenProviders();

		#region JWT
		var appSettingsSection = builder.Configuration.GetSection("AppSettings");
		builder.Services.Configure<AppSettings>(appSettingsSection);

		var appSettings = appSettingsSection.Get<AppSettings>();
		var key = Encoding.ASCII.GetBytes(appSettings.Secret);

		builder.Services.AddAuthentication(options => {
			options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
		}).AddJwtBearer(options => {
			options.RequireHttpsMetadata = true;
			options.SaveToken = true;
			options.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(key),
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidateLifetime = true,
				ValidAudience = appSettings.ValidoEm,
				ValidIssuer = appSettings.Emissor
			};
		});
		#endregion
	}
}
