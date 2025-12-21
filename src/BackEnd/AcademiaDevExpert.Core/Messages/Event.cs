using MediatR;

namespace AcademiaDevExpert.Core.Messages;

public abstract class Event : Message, INotification
{
	public DateTime Timestamp { get; private set; } = DateTime.Now;
}
