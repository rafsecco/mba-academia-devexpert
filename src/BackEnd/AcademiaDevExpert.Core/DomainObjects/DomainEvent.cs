using AcademiaDevExpert.Core.Messages;

namespace AcademiaDevExpert.Core.DomainObjects;

public class DomainEvent : Event
{
	public DomainEvent(Guid aggregateId)
	{
		AggregateId = aggregateId;
	}
}
