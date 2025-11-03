using AcademiaDevExpert.Core.DomainObjects;

namespace AcademiaDevExpert.Core.Data;

public interface IRepository<T> : IDisposable where T : IAggregateRoot
{
	IUnitOfWork UnitOfWork { get; }
}
