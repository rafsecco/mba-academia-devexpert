using academia_devexpert.API.Data;
using academia_devexpert.Data;
using Microsoft.EntityFrameworkCore;

namespace academia_devexpert.API.Configuracoes;

public static class DatabaseSelectorExtension
{
	public static void AddDatabaseSelector(this WebApplicationBuilder builder)
	{
		var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

		if (string.IsNullOrWhiteSpace(connectionString))
		{
			throw new InvalidOperationException("A string de conexão 'DefaultConnection' está ausente ou vazia.");
		}

		switch (builder.Environment.EnvironmentName)
		{
			case "Development":
				builder.Services.AddDbContext<SolutionDbContext>(o => o.UseSqlite(connectionString));
				builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseSqlite(connectionString));
				break;
			case "Production":
				builder.Services.AddDbContext<SolutionDbContext>(o => o.UseSqlServer(connectionString));
				builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(connectionString));
				break;
			default:
				throw new InvalidOperationException($"Ambiente não suportado '{builder.Environment.EnvironmentName}'.");
		}
	}
}
