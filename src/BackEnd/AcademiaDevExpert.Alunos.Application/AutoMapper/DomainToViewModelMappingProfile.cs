using AcademiaDevExpert.Alunos.Domain;
using AutoMapper;

namespace AcademiaDevExpert.Alunos.Application.AutoMapper;

public class DomainToViewModelMappingProfile : Profile
{
	public DomainToViewModelMappingProfile()
	{
		CreateMap<Aluno, ViewModels.AlunoViewModel>();
		CreateMap<Matricula, ViewModels.MatriculaViewModel>();
	}
}
