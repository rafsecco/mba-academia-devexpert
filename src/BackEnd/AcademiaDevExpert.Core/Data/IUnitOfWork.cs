namespace AcademiaDevExpert.Core.Data;

public interface IUnitOfWork
{
	Task<bool> Commit();
}
