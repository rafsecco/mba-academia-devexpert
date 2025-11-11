using AcademiaDevExpert.Core.DomainObjects;

namespace AcademiaDevExpert.Conteudo.Domain;

public class ConteudoProgramatico
{
	public string Titulo { get; private set; }
	public string Descricao { get; private set; }

	protected ConteudoProgramatico() { }

	public ConteudoProgramatico(string titulo, string descricao)
	{
		Titulo = titulo;
		Descricao = descricao;

		Validacoes.ValidarSeVazio(Titulo, "O Título do conteúdo programático não pode estar vazio");
		Validacoes.ValidarSeVazio(Descricao, "A Descrição do conteúdo programático não pode estar vazio");
	}
}
