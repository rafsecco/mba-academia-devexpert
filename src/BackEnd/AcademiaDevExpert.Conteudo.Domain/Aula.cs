using AcademiaDevExpert.Core.DomainObjects;

namespace AcademiaDevExpert.Conteudo.Domain;

public class Aula : Entity
{
	public string Titulo { get; set; }
	public string Descricao { get; set; }
	public TimeSpan Duracao { get; set; }

	public Guid CursoId { get; set; }
	public Curso Curso { get; set; }

	public Aula(string titulo, string descricao, TimeSpan duracao, Guid cursoId)
	{
		Titulo = titulo;
		Descricao = descricao;
		Duracao = duracao;
		CursoId = cursoId;

		Validar();
	}

	public void Validar()
	{
		Validacoes.ValidarSeVazio(Titulo, "O campo Título da aula não pode estar vazio");
		Validacoes.ValidarSeVazio(Descricao, "O campo Conteúdo da aula não pode estar vazio");
		Validacoes.ValidarSeMenorQue(Duracao.TotalMinutes, 1.0, "A duração da aula deve ser maior que zero");

		Validacoes.ValidarSeIgual(CursoId, Guid.Empty, "O campo CursoId da aula não pode estar vazio");
	}
}
