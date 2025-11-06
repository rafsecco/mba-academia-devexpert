using System.ComponentModel.DataAnnotations;

namespace AcademiaDevExpert.Conteudo.Application.ViewModels;

public class AulaViewModel
{
	[Key]
	public Guid Id { get; set; }

	[Required(ErrorMessage = "O campo {0} é obrigatório")]
	public Guid CursoId { get; set; }

	[Required(ErrorMessage = "O campo {0} é obrigatório")]
	public string Titulo { get; set; }

	[Required(ErrorMessage = "O campo {0} é obrigatório")]
	public string Descricao { get; set; }

	[Required(ErrorMessage = "O campo {0} é obrigatório")]
	public TimeSpan Duracao { get; set; }
}
