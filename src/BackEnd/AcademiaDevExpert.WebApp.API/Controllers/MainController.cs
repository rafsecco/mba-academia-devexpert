using AcademiaDevExpert.Core.Communication.Mediator;
using AcademiaDevExpert.Core.Messages.CommonMessages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaDevExpert.WebApp.API.Controllers;

public class MainController : ControllerBase
{
	private readonly IMediatorHandler _mediatorHandler;
	private readonly DomainNotificationHandler _notifications;

	public MainController(IMediatorHandler mediatrHandler, INotificationHandler<DomainNotification> notifications)
	{
		_mediatorHandler = mediatrHandler;
		_notifications = (DomainNotificationHandler)notifications;
	}

	protected bool OperacaoValida()
	{
		return !_notifications.TemNotificacao();
	}

	protected IEnumerable<string> ObterMensagensErro()
	{
		return _notifications.ObterNotificacoes().Select(c => c.Value).ToList();
	}

	protected void NotificarErro(string codigo, string mensagem)
	{
		_mediatorHandler.PublicarNotificacao(new DomainNotification(codigo, mensagem));
	}
}
