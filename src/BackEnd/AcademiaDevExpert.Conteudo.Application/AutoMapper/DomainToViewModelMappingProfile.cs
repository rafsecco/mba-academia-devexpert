using AutoMapper;

namespace AcademiaDevExpert.Conteudo.Application.AutoMapper;

public class DomainToViewModelMappingProfile : Profile
{
	public DomainToViewModelMappingProfile()
	{
		CreateMap<Conteudo.Domain.Curso, ViewModels.CursoViewModel>();
		CreateMap<Conteudo.Domain.Aula, ViewModels.AulaViewModel>();
	}
}
