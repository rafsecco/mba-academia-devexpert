using AcademiaDevExpert.Alunos.Domain;
using AcademiaDevExpert.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace AcademiaDevExpert.Alunos.Data.Repository;

public class AlunoRepository : IAlunoRepository
{
	private readonly AlunosContext _context;

	public AlunoRepository(AlunosContext context)
	{
		_context = context;
	}

	public IUnitOfWork UnitOfWork => _context;

	public async Task<IEnumerable<Aluno>> ObterTodos()
	{
		return await _context.Alunos.AsNoTracking().ToListAsync();
	}

	public async Task<Aluno> ObterAlunoPorId(Guid id) => await _context.Alunos.AsNoTracking().FirstAsync(c => c.Id == id);

	public async Task AdicionarAluno(Aluno aluno)
	{
		await _context.Alunos.AddAsync(aluno);
	}

	public async Task AdicionarMatricula(Guid userId, Guid cursoId)
	{
		var matricula = new Matricula(userId, cursoId);
		await _context.Matriculas.AddAsync(matricula);
	}

	public void Dispose()
	{
		_context?.Dispose();
	}
}
