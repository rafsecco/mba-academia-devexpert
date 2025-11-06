namespace AcademiaDevExpert.Curso.Domain;

public interface ICargaHorariaService : IDisposable
{
	Task<bool> AcrescentarCargaHorariaAsync(Guid cursoId, TimeSpan cargaHoraria);
	Task<bool> DebitarCargaHorariaAsync(Guid cursoId, TimeSpan cargaHoraria);
}
