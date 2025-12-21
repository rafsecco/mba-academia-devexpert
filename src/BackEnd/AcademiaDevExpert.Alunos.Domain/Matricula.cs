using AcademiaDevExpert.Core.DomainObjects;

namespace AcademiaDevExpert.Alunos.Domain;

public class Matricula : Entity
{
	public Guid AlunoId { get; private set; }
	public Aluno Aluno { get; private set; }
	public Guid CursoId { get; private set; }
	public enumStatusMatricula StatusMatricula { get; private set; } = enumStatusMatricula.PagamentoPendente;

	public Matricula(Guid alunoId, Guid cursoId)
	{
		AlunoId = alunoId;
		CursoId = cursoId;
	}

	public void AtualizarStatusMatricula(enumStatusMatricula status)
	{
		StatusMatricula = status;
	}

	protected Matricula() { }
}
