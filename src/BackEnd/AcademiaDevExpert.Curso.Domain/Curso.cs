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

	public Curso(string titulo, string descricao, bool ativo, decimal valor, string imagem, TimeSpan cargaHoraria)
	{
		Titulo = titulo;
		Descricao = descricao;
		Ativo = ativo;
		Valor = valor;
		Imagem = imagem;
		CargaHoraria = cargaHoraria;
	}

	public void Ativar() => Ativo = true;

	public void Desativar() => Ativo = false;

	public void Validar()
	{

	}

}
