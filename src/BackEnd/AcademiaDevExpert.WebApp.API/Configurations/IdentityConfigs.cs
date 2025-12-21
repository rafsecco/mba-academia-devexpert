using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace AcademiaDevExpert.WebApp.API.Configurations;

public static class IdentityConfigs
{
	public static IServiceCollection AddIdentityConfig(this IServiceCollection services,
														WebApplicationBuilder builder)
	{
		if (builder.Environment.IsDevelopment())
		{
			services.AddDbContext<AuthDbContext>(options =>
			options.UseSqlite(builder.Configuration.GetConnectionString("AuthDefaultConnection")));
		}
		else
		{
			services.AddDbContext<AuthDbContext>(options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString("AuthDefaultConnection")));
		}
		services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
		{
			options.Password.RequireNonAlphanumeric = false;
			options.Password.RequiredLength = 8;
			options.Password.RequireUppercase = false;
			options.Password.RequireLowercase = false;
			options.User.RequireUniqueEmail = true;
			options.SignIn.RequireConfirmedAccount = false;
			options.SignIn.RequireConfirmedEmail = false;
			options.SignIn.RequireConfirmedPhoneNumber = false;
		})
	  .AddEntityFrameworkStores<AuthDbContext>()
	  .AddDefaultTokenProviders();


		// JWT
		var appSettingsSection = builder.Configuration.GetSection("appsettings");
		services.Configure<AppSettings>(appSettingsSection);

		var appSettings = appSettingsSection.Get<AppSettings>();
		var key = Encoding.ASCII.GetBytes(appSettings.Secret);

		services.AddAuthentication(x =>
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
				ValidAudience = appSettings.ValidoEm,
				ValidIssuer = appSettings.Emissor
			};
		});

		return services;
	}
}

