using AcademiaDevExpert.Conteudo.Data;
using Microsoft.EntityFrameworkCore;

namespace AcademiaDevExpert.WebApp.API.Configurations;

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
				builder.Services.AddDbContext<ConteudoContext>(o => o.UseSqlite(connectionString));
				break;
			case "Production":
				builder.Services.AddDbContext<ConteudoContext>(o => o.UseSqlServer(connectionString));
				break;
			default:
				throw new InvalidOperationException($"Ambiente não suportado '{builder.Environment.EnvironmentName}'.");
		}
	}
}
