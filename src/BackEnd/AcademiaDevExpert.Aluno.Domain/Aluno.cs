using AcademiaDevExpert.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaDevExpert.Aluno.Domain;

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
}
