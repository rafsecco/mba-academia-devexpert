using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaDevExpert.Conteudo.Application.AutoMapper;

public class DomainToViewModelMappingProfile : Profile
{
	public DomainToViewModelMappingProfile()
	{
		CreateMap<Curso.Domain.Curso, ViewModels.CursoViewModel>();
		CreateMap<Curso.Domain.Aula, ViewModels.AulaViewModel>();
	}
}
