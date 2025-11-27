using System.ComponentModel.DataAnnotations;

namespace AcademiaDevExpert.Alunos.Application.ViewModels;

public class AlunoViewModel
{
	[Key]
	public Guid Id { get; set; }

	[Required(ErrorMessage = "O campo {0} é obrigatório")]
	public string Nome { get; set; }

	[Required(ErrorMessage = "O campo {0} é obrigatório")]
	public string SobreNome { get; set; }

	[Required(ErrorMessage = "O campo {0} é obrigatório")]
	public string Email { get; set; }
}
