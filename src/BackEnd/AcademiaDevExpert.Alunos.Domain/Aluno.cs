using AcademiaDevExpert.Core.DomainObjects;

namespace AcademiaDevExpert.Alunos.Domain;

public class Aluno : Entity, IAggregateRoot
{
	public string Nome { get; private set; }
	public string SobreNome { get; private set; }
	public string Email { get; private set; }

	public Aluno(string nome, string sobreNome, string email)
	{
		Nome = nome;
		SobreNome = sobreNome;
		Email = email;
	}

	public void Validar()
	{
		Validacoes.ValidarSeVazio(Nome, "O nome do aluno não pode estar vazio");
		Validacoes.ValidarSeVazio(SobreNome, "O sobrenome do aluno não pode estar vazio");
		Validacoes.ValidarSeVazio(Email, "O email do aluno não pode estar vazio");

		Validacoes.ValidarTamanho(Nome, 150, "O nome do aluno não pode ter mais de 150 caracteres");
		Validacoes.ValidarTamanho(SobreNome, 150, "O sobre nome do aluno não pode ter mais de 150 caracteres");
		Validacoes.ValidarTamanho(Email, 255, "O email do aluno não pode ter mais de 255 caracteres");
	}
}
