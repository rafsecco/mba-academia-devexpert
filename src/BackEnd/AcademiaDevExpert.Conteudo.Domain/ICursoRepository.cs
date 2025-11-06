using AcademiaDevExpert.Core.Data;

namespace AcademiaDevExpert.Conteudo.Domain;

public interface ICursoRepository : IRepository<Curso>
{
	Task<IEnumerable<Curso>> ObterTodos();
	Task<Curso> ObterPorId(Guid id);
	Task<IEnumerable<Aula>> ObterTodasAulas(Guid cursoId);
	Task<Aula> ObterAula(Guid aulaId);

	void AdicionarCurso(Curso curso);
	void AtualizarCurso(Curso curso);

	void AdicionarAula(Aula aula);
}
