using AcademiaDevExpert.Conteudo.Application.ViewModels;
using AutoMapper;
using AcademiaDevExpert.Curso.Domain;

namespace AcademiaDevExpert.Conteudo.Application.AutoMapper;

public class ViewModelToDomainMappingProfile : Profile
{
	public ViewModelToDomainMappingProfile()
	{
		CreateMap<CursoViewModel, Curso.Domain.Curso>()
			.ConstructUsing(c =>
				new Curso.Domain.Curso(
					c.Titulo,
					c.Descricao,
					c.Ativo,
					c.Valor,
					c.Imagem,
					new ConteudoProgramatico(
						c.ConteudoProgramatico.Titulo,
						c.ConteudoProgramatico.Descricao
					)
				)
			);

		CreateMap<AulaViewModel, Aula>()
			.ConstructUsing(a =>
				new Aula(
					a.Titulo,
					a.Descricao,
					a.Duracao,
					a.CursoId
				)
			);
	}
}
