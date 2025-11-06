using System.ComponentModel.DataAnnotations;

namespace AcademiaDevExpert.Conteudo.Application.ViewModels;

public class ConteudoProgramaticoViewModel
{
	[Required(ErrorMessage = "O campo {0} é obrigatório")]
	public string Titulo { get; set; }

	[Required(ErrorMessage = "O campo {0} é obrigatório")]
	public string Descricao { get; set; }

}
