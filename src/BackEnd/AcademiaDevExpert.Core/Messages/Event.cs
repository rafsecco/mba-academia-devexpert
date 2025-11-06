using MediatR;
using System.Transactions;

namespace AcademiaDevExpert.Core.Messages;

public abstract class Event : Message, INotification
{
	public DateTime Timestamp { get; private set; } = DateTime.Now;
}
