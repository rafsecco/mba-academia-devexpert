using academia_devexpert.API.Data;
using academia_devexpert.API.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace academia_devexpert.API.Configuracoes;

public static class IdentityConfigs
{
	public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configurations)
	{
		string strConn = configurations.GetConnectionString("DefaultConnection");

		services.AddDbContext<ApplicationDbContext>(options =>
			options.UseSqlServer(strConn));

		services.AddIdentity<IdentityUser, IdentityRole>(options =>
		{
			//options.Password.RequireDigit = true;
			//options.Password.RequireLowercase = true;
			//options.Password.RequireNonAlphanumeric = true;
			//options.Password.RequireUppercase = true;
			//options.Password.RequiredLength = 6;
			//options.Password.RequiredUniqueChars = 1;
			//options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
			//options.Lockout.MaxFailedAccessAttempts = 5;
			//options.Lockout.AllowedForNewUsers = true;
			//options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
			options.SignIn.RequireConfirmedEmail = false;
			options.User.RequireUniqueEmail = true;
		})
			.AddRoles<IdentityRole>()
			.AddEntityFrameworkStores<ApplicationDbContext>()
			.AddErrorDescriber<IdentityMensagensPortugues>()
			.AddDefaultTokenProviders();

		return services;
	}
}
