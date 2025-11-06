using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaDevExpert.Conteudo.Application.ViewModels;

public class ConteudoProgramaticoViewModel
{
	[Required(ErrorMessage = "O campo {0} é obrigatório")]
	public string Titulo { get; set; }

	[Required(ErrorMessage = "O campo {0} é obrigatório")]
	public string Descricao { get; set; }

}
