using AcademiaDevExpert.Core.DomainObjects;

namespace AcademiaDevExpert.Conteudo.Domain;

public class Curso : Entity, IAggregateRoot
{
	public string Titulo { get; private set; }
	public string Descricao { get; private set; }
	public bool Ativo { get; private set; }
	public decimal Valor { get; private set; }
	public string Imagem { get; private set; }
	public TimeSpan CargaHoraria { get; private set; }

	public ConteudoProgramatico ConteudoProgramatico { get; private set; }

	// EF Relation
	public ICollection<Aula> Aulas { get; private set; } = [];
	protected Curso() { }

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

	public void AcrescentarCargaHoraria(TimeSpan duracao)
	{
		Validacoes.ValidarSeMenorQue(duracao.Milliseconds, TimeSpan.Zero.Milliseconds, "A duração não pode ser negativa");
		CargaHoraria += duracao;
	}

	public void DebitarCargaHoraria(TimeSpan duracao)
	{
		Validacoes.ValidarSeMenorQue(duracao.Milliseconds, TimeSpan.Zero.Milliseconds, "A duração não pode ser negativa");
		CargaHoraria -= duracao;
	}


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
		Validacoes.ValidarSeMenorQue(Valor, 0, "O valor do curso não pode ser negativo");
		Validacoes.ValidarSeVazio(Imagem, "A imagem do curso não pode estar vazia");
		//Validacoes.ValidarSeMenorIgualQue(CargaHoraria.TotalMinutes, TimeSpan.Zero.TotalMinutes, "A carga horária do curso deve ser maior que zero");

		Validacoes.ValidarTamanho(Titulo, 150, "O título do curso não pode ter mais de 150 caracteres");
		Validacoes.ValidarTamanho(Descricao, 5000, "A descrição do curso não pode ter mais de 5000 caracteres");
	}
}
