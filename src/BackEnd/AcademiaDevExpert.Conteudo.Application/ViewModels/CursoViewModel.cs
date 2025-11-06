using System.ComponentModel.DataAnnotations;

namespace AcademiaDevExpert.Conteudo.Application.ViewModels;

public class CursoViewModel
{
	[Key]
	public Guid Id { get; set; }

	[Required(ErrorMessage = "O campo {0} é obrigatório")]
	public string Titulo { get; set; }

	[Required(ErrorMessage = "O campo {0} é obrigatório")]
	public string Descricao { get; set; }

	public bool Ativo { get; set; }

	[Required(ErrorMessage = "O campo {0} é obrigatório")]
	public decimal Valor { get; set; }

	public string Imagem { get; set; }

	[Required(ErrorMessage = "O campo {0} é obrigatório")]
	public TimeSpan CargaHoraria { get; set; }

	public ConteudoProgramaticoViewModel ConteudoProgramatico { get; set; }

	public IEnumerable<AulaViewModel> Aulas { get; set; }
}
