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
			//c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
			//{
			//	Description = "Insira o Token JWT dessa forma: 'Bearer {seu token}'.\n\r\r\n Exemplo: \"Bearer 12345abcdef\"",
			//	Name = "Autorização",
			//	Scheme = "Bearer",
			//	BearerFormat = "JWT",
			//	In = ParameterLocation.Header,
			//	Type = SecuritySchemeType.ApiKey,
			//});
			//c.AddSecurityRequirement(new OpenApiSecurityRequirement
			//{
			//	{
			//		new OpenApiSecurityScheme
			//		{
			//			Reference = new OpenApiReference
			//			{
			//				Type = ReferenceType.SecurityScheme,
			//				Id = "Bearer"
			//			}
			//		},
			//		Array.Empty<string>()
			//	}
			//});
		});
		return services;
	}

	public static WebApplication UseSwaggerConfiguration(this WebApplication app)
	{
		if (app.Environment.IsDevelopment())
		{
			app.MapOpenApi();
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Academia DevExpert API v1");
				c.RoutePrefix = string.Empty; // Isso faz com que o Swagger abra diretamente no root ("/")
			});
		}
		return app;
	}
}
