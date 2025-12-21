using AcademiaDevExpert.Core.Messages;
using AcademiaDevExpert.Core.Messages.CommonMessages.Notifications;

namespace AcademiaDevExpert.Core.Communication.Mediator;

public interface IMediatorHandler
{
	Task PublicarEvento<T>(T evento) where T : Event;
	Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification;
	Task<bool> EnviarComando<T>(T comando) where T : Command;
}
