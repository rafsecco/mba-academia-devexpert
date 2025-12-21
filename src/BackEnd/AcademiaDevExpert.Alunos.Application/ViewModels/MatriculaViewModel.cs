using AcademiaDevExpert.Alunos.Domain;
using System.ComponentModel.DataAnnotations;

namespace AcademiaDevExpert.Alunos.Application.ViewModels;

public class MatriculaViewModel
{
	[Key]
	public Guid Id { get; set; }

	[Required(ErrorMessage = "O campo {0} é obrigatório")]
	public Guid AlunoId { get; set; }

	[Required(ErrorMessage = "O campo {0} é obrigatório")]
	public Guid CursoId { get; set; }

	[Required(ErrorMessage = "O campo {0} é obrigatório")]
	public enumStatusMatricula StatusMatricula { get; set; }
}
