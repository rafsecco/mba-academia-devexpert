using AcademiaDevExpert.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaDevExpert.Curso.Domain;

public class Aula : Entity
{
	public string Titulo { get; set; }
	public string Conteudo { get; set; }
	public TimeSpan Duracao { get; set; }

	public Guid CursoId { get; set; }
	public Curso Curso { get; set; }

	public Aula(string titulo, string conteudo, TimeSpan duracao, Guid cursoId)
	{
		Titulo = titulo;
		Conteudo = conteudo;
		Duracao = duracao;
		CursoId = cursoId;

		Validar();
	}

	public void Validar()
	{
		Validacoes.ValidarSeVazio(Titulo, "O campo Título da aula não pode estar vazio");
		Validacoes.ValidarSeVazio(Conteudo, "O campo Conteúdo da aula não pode estar vazio");
		Validacoes.ValidarSeMenorQue(Duracao.TotalMinutes, 1.0, "A duração da aula deve ser maior que zero");

		Validacoes.ValidarSeIgual(CursoId, Guid.Empty, "O campo CursoId da aula não pode estar vazio");
	}
}
