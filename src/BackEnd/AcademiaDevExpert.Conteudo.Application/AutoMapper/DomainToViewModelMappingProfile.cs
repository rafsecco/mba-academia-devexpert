using AcademiaDevExpert.Conteudo.Domain;
using AutoMapper;

namespace AcademiaDevExpert.Conteudo.Application.AutoMapper;

public class DomainToViewModelMappingProfile : Profile
{
	public DomainToViewModelMappingProfile()
	{
		CreateMap<Curso, ViewModels.CursoViewModel>();
		CreateMap<Aula, ViewModels.AulaViewModel>();
	}
}
