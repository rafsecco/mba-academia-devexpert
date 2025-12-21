using AcademiaDevExpert.Core.Data;

namespace AcademiaDevExpert.Alunos.Domain;

public interface IAlunoRepository : IRepository<Aluno>
{
	Task<IEnumerable<Aluno>> ObterTodos();
	Task<Aluno> ObterAlunoPorId(Guid userId);
	Task AdicionarAluno(Aluno aluno);
	Task AdicionarMatricula(Guid userId, Guid cursoId);
}
