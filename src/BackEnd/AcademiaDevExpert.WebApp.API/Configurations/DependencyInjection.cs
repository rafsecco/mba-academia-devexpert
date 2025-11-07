using AcademiaDevExpert.Conteudo.Data;
using AcademiaDevExpert.Conteudo.Data.Repository;
using AcademiaDevExpert.Conteudo.Domain;
using AcademiaDevExpert.Core.Bus;
using Microsoft.Extensions.DependencyInjection;

namespace AcademiaDevExpert.WebApp.API.Configurations;

public static class DependencyInjection
{
	public static void RegisterServices(this IServiceCollection services)
	{
		// Domain bus (Mediator)
		services.AddScoped<IMediatrHandler, MediatrHandler>();

		// Conteudo
		services.AddScoped<ICursoRepository, CursoRepository>();
		services.AddScoped<ICargaHorariaService, CargaHorariaService>();
		services.AddScoped<ConteudoContext>();
	}
}
