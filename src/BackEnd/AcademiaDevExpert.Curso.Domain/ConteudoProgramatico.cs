using AcademiaDevExpert.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaDevExpert.Curso.Domain;

public class ConteudoProgramatico
{
	public string Titulo { get; private set; }
	public string Descricao { get; private set; }

	public ConteudoProgramatico(string titulo, string descricao)
	{
		Titulo = titulo;
		Descricao = descricao;

		Validacoes.ValidarSeVazio(Titulo, "O Título do conteúdo programático não pode estar vazio");
		Validacoes.ValidarSeVazio(Descricao, "A Descrição do conteúdo programático não pode estar vazio");
	}
}
