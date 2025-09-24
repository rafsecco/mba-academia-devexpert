using Microsoft.OpenApi.Models;

namespace academia_devexpert.API.Configuracoes;

public static class SwaggerConfigs
{
	public static IServiceCollection AddSwaggerConfigureServices(this IServiceCollection services)
	{
		services.AddOpenApi();
		services.AddEndpointsApiExplorer();
		services.AddSwaggerGen(c =>
		{
			c.SwaggerDoc("v1", new OpenApiInfo { Title = "Academia DevExpert API", Version = "v1", Description = "Documentação da API com autenticação JWT" });
		});
		return services;
	}

	public static WebApplication UseSwaggerConfiguration(this WebApplication app)
	{
		if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Docker"))
		{
			app.MapOpenApi();
			app.UseSwagger();
			app.UseSwaggerUI(c =>
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Academia DevExpert API v1")
			);
		}
		return app;
	}
}
