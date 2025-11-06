using AcademiaDevExpert.Core.Messages;

namespace AcademiaDevExpert.Core.Bus;

public interface IMediatrHandler
{
	Task PublicarEvento<T>(T evento) where T : Event;
}
