using AcademiaDevExpert.WebApp.API.Data;
using AcademiaDevExpert.WebApp.API.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace AcademiaDevExpert.WebApp.API.Configurations;

public static class IdentityConfigs
{
	public static void AddIdentityConfig(this WebApplicationBuilder builder)
	{
		if (builder.Environment.IsDevelopment())
		{
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
			options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
		}
		else
		{
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
		}

		builder.Services.AddDefaultIdentity<IdentityUser>(options =>
		{
			// Password settings
			//options.Password.RequireDigit = true;
			//options.Password.RequiredLength = 8;
			//options.Password.RequireNonAlphanumeric = true;
			//options.Password.RequireUppercase = true;
			//options.Password.RequireLowercase = true;
			//options.Password.RequiredUniqueChars = 6;

			//options.User.AllowedUserNameCharacters = AllowedUserNameCharacters;

			//options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
			//options.Lockout.MaxFailedAccessAttempts = 3;

			options.SignIn.RequireConfirmedEmail = false;
			options.User.RequireUniqueEmail = true;
		}).AddRoles<IdentityRole>()
			.AddEntityFrameworkStores<ApplicationDbContext>();

		// JWT
		var appSettingsSection = builder.Configuration.GetSection("JwtSettings");
		builder.Services.Configure<JwtSettings>(appSettingsSection);

		var appSettings = appSettingsSection.Get<JwtSettings>();
		var key = Encoding.ASCII.GetBytes(appSettings.Secret);

		builder.Services.AddAuthentication(x =>
		{
			x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
		}).AddJwtBearer(x =>
		{
			x.RequireHttpsMetadata = true;
			x.SaveToken = true;
			x.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(key),
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidAudience = appSettings.Audience,
				ValidIssuer = appSettings.Issuer
			};
		});
	}
}

