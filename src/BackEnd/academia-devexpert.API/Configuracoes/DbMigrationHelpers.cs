using academia_devexpert.API.Data;
using academia_devexpert.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace academia_devexpert.API.Configuracoes;

public static class DbMigrationHelperExtension
{
	public static void UseDbMigrationHelper(this WebApplication app)
	{
		DbMigrationHelpers.EnsureSeedData(app).Wait();
	}
}

public static class DbMigrationHelpers
{
	public static async Task EnsureSeedData(WebApplication serviceScope)
	{
		var services = serviceScope.Services.CreateScope().ServiceProvider;
		await EnsureSeedData(services);
	}

	public static async Task EnsureSeedData(IServiceProvider serviceProvider)
	{
		using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
		var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

		var context = scope.ServiceProvider.GetRequiredService<SolutionDbContext>();
		var contextIdentity = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

		if (!env.IsProduction())
		{
			await context.Database.MigrateAsync();
			await contextIdentity.Database.MigrateAsync();
			await EnsureSeedDatabase(context, contextIdentity);
		}
		else
		{
			await context.Database.MigrateAsync();
			await contextIdentity.Database.MigrateAsync();
			await SeedUserAdmin(contextIdentity);
		}
	}

	private static async Task EnsureSeedDatabase(SolutionDbContext ctx, ApplicationDbContext ctxId)
	{
		await SeedUserAdmin(ctxId);
	}

	private static async Task SeedUserAdmin(ApplicationDbContext ctxId)
	{
		if (ctxId.Users.Any())
			return;

		await ctxId.Users.AddAsync(new IdentityUser
		{
			Id = Guid.NewGuid().ToString(),
			UserName = "admin@admin.com",
			NormalizedUserName = "ADMIN@ADMIN.COM",
			Email = "admin@admin.com",
			NormalizedEmail = "ADMIN@ADMIN.COM",
			AccessFailedCount = 0,
			LockoutEnabled = false,
			PasswordHash = "AQAAAAIAAYagAAAAEEdWhqiCwW/jZz0hEM7aNjok7IxniahnxKxxO5zsx2TvWs4ht1FUDnYofR8JKsA5UA==", // Teste@123
			TwoFactorEnabled = false,
			ConcurrencyStamp = Guid.NewGuid().ToString(),
			EmailConfirmed = true,
			SecurityStamp = Guid.NewGuid().ToString()
		});

		await ctxId.SaveChangesAsync();
	}
}
