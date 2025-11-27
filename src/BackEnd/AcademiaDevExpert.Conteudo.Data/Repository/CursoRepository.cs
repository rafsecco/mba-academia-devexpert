using AcademiaDevExpert.Conteudo.Domain;
using AcademiaDevExpert.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace AcademiaDevExpert.Conteudo.Data.Repository;

public class CursoRepository : ICursoRepository
{
	private readonly ConteudoContext _context;

	public CursoRepository(ConteudoContext context)
	{
		_context = context;
	}

	public IUnitOfWork UnitOfWork => _context;

	#region Curso
	public async Task<IEnumerable<Curso>> ObterTodos()
	{
		return await _context.Cursos.AsNoTracking().ToListAsync();
	}

	public async Task<Curso> ObterPorId(Guid id)
	{
		return await _context.Cursos.AsNoTracking()
			.FirstOrDefaultAsync(c => c.Id == id);
	}

	public void AdicionarCurso(Curso curso)
	{
		_context.Cursos.Add(curso);
	}

	public void AtualizarCurso(Curso curso)
	{
		_context.Cursos.Update(curso);
	}
	#endregion

	#region Aula
	public async Task<IEnumerable<Aula>> ObterTodasAulas(Guid cursoId)
	{
		return await _context.Cursos.AsNoTracking()
			.Include(a => a.Aulas)
			.Where(c => c.Id == cursoId)
			.SelectMany(c => c.Aulas).ToListAsync();
	}

	public async Task<Aula> ObterAula(Guid aulaId)
	{
		return await _context.Aulas.AsNoTracking()
			.FirstOrDefaultAsync(a => a.Id == aulaId);
	}

	public void AdicionarAula(Aula aula)
	{
		_context.Aulas.Add(aula);
	}
	#endregion

	public void Dispose()
	{
		_context?.Dispose();
	}
}
