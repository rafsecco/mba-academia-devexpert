namespace AcademiaDevExpert.Conteudo.Domain;

public class CargaHorariaService : ICargaHorariaService
{
	private readonly ICursoRepository _cursoRepository;

	public CargaHorariaService(ICursoRepository cursoRepository)
	{
		_cursoRepository = cursoRepository;
	}

	public async Task<bool> AcrescentarCargaHorariaAsync(Guid cursoId, TimeSpan cargaHoraria)
	{
		var curso = await _cursoRepository.ObterPorId(cursoId);
		if (curso == null) return false;
		curso.AcrescentarCargaHoraria(cargaHoraria);
		_cursoRepository.AtualizarCurso(curso);
		return await _cursoRepository.UnitOfWork.Commit();
	}

	public async Task<bool> DebitarCargaHorariaAsync(Guid cursoId, TimeSpan cargaHoraria)
	{
		var curso = await _cursoRepository.ObterPorId(cursoId);
		if (curso == null) return false;
		curso.DebitarCargaHoraria(cargaHoraria);
		_cursoRepository.AtualizarCurso(curso);
		return await _cursoRepository.UnitOfWork.Commit();
	}

	public void Dispose()
	{
		_cursoRepository.Dispose();
	}
}
