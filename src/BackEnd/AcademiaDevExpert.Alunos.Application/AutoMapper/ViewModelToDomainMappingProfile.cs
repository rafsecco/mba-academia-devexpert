using AcademiaDevExpert.Alunos.Application.ViewModels;
using AcademiaDevExpert.Alunos.Domain;
using AutoMapper;

namespace AcademiaDevExpert.Alunos.Application.AutoMapper;

public class ViewModelToDomainMappingProfile : Profile
{
	public ViewModelToDomainMappingProfile()
	{
		CreateMap<AlunoViewModel, Aluno>()
			.ConstructUsing(a =>
				new Aluno(a.Nome, a.SobreNome, a.Email)
			);

		CreateMap<MatriculaViewModel, Matricula>()
			.ConstructUsing(m =>
				new Matricula(m.AlunoId, m.CursoId)
			);
	}
}
