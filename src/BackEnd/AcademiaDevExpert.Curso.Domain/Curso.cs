using AcademiaDevExpert.Core.DomainObjects;

namespace AcademiaDevExpert.Curso.Domain;

public class Curso : Entity, IAggregateRoot
{
	public string Titulo { get; private set; }
	public string Descricao { get; private set; }
	public bool Ativo { get; private set; }
	public decimal Valor { get; private set; }
	public string Imagem { get; private set; }
	public TimeSpan CargaHoraria { get; private set; }

	public List<Aula> Aulas { get; private set; } = new();
	public ConteudoProgramatico ConteudoProgramatico { get; private set; }

	public Curso(string titulo, string descricao, bool ativo, decimal valor, string imagem, ConteudoProgramatico conteudoProgramatico)
	{
		Titulo = titulo;
		Descricao = descricao;
		Ativo = ativo;
		Valor = valor;
		Imagem = imagem;
		ConteudoProgramatico = conteudoProgramatico;

		Validar();
	}

	public void Ativar() => Ativo = true;

	public void Desativar() => Ativo = false;

	public void AddAula(Aula aula)
	{
		Aulas.Add(aula);
		CargaHoraria += aula.Duracao;
	}

	public void AtualizarConteudo(ConteudoProgramatico novoConteudo)
	{
		ConteudoProgramatico = novoConteudo;
	}

	public void Validar()
	{
		Validacoes.ValidarSeVazio(Titulo, "O título do curso não pode estar vazio");
		Validacoes.ValidarSeVazio(Descricao, "A descrição do curso não pode estar vazia");
		Validacoes.ValidarSeMenorQue(0, Valor, "O valor do curso não pode ser negativo");
		//Validacoes.ValidarSeMenorIgualQue(CargaHoraria.TotalMinutes, TimeSpan.Zero.TotalMinutes, "A carga horária do curso deve ser maior que zero");

		Validacoes.ValidarTamanho(Titulo, 150, "O título do curso não pode ter mais de 150 caracteres");
		Validacoes.ValidarTamanho(Descricao, 5000, "A descrição do curso não pode ter mais de 5000 caracteres");
	}
}
