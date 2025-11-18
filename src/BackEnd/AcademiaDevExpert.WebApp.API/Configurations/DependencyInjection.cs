using AcademiaDevExpert.Conteudo.Data;
using AcademiaDevExpert.Conteudo.Data.Repository;
using AcademiaDevExpert.Conteudo.Domain;
using AcademiaDevExpert.Core.Communication.Mediator;
using AcademiaDevExpert.Core.Messages.CommonMessages.Notifications;
using MediatR;

namespace AcademiaDevExpert.WebApp.API.Configurations;

public static class DependencyInjection
{
	public static void RegisterServices(this IServiceCollection services)
	{
		// Mediator
		services.AddScoped<IMediatorHandler, MediatorHandler>();

		// Notifications
		services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

		// Conteudo
		services.AddScoped<ICursoRepository, CursoRepository>();
		services.AddScoped<ICargaHorariaService, CargaHorariaService>();
		services.AddScoped<ConteudoContext>();
	}
}
