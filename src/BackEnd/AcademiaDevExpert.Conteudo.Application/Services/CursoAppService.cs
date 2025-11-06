using AcademiaDevExpert.Conteudo.Application.ViewModels;
using AcademiaDevExpert.Curso.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaDevExpert.Conteudo.Application.Services;

public class CursoAppService : ICursoAppService
{
	private readonly ICursoRepository _cursoRepository;
	private readonly IMapper _mapper;

	public CursoAppService(ICursoRepository cursoRepository, IMapper mapper)
	{
		_cursoRepository = cursoRepository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<CursoViewModel>> ObterTodos()
	{
		return _mapper.Map<IEnumerable<CursoViewModel>>(await _cursoRepository.ObterTodos());
	}
	
	public async Task<CursoViewModel> ObterPorId(Guid id)
	{
		return _mapper.Map<CursoViewModel>(await _cursoRepository.ObterPorId(id));
	}

	public async Task Adicionar(CursoViewModel cursoViewModel)
	{
		var curso = _mapper.Map<Curso.Domain.Curso>(cursoViewModel);
		_cursoRepository.AdicionarCurso(curso);
		await _cursoRepository.UnitOfWork.Commit();
	}

	public async Task Atualizar(CursoViewModel cursoViewModel)
	{
		var curso = _mapper.Map<Curso.Domain.Curso>(cursoViewModel);
		_cursoRepository.AtualizarCurso(curso);
		await _cursoRepository.UnitOfWork.Commit();
	}


	public async Task<IEnumerable<AulaViewModel>> ObterTodasAulas(Guid cursoId)
	{
		return _mapper.Map<IEnumerable<AulaViewModel>>(await _cursoRepository.ObterTodasAulas(cursoId));
	}

	public async Task<AulaViewModel> ObterAula(Guid aulaId)
	{
		return _mapper.Map<AulaViewModel>(await _cursoRepository.ObterAula(aulaId));
	}

	public async Task AdicionarAula(AulaViewModel aulaViewModel)
	{
		var aula = _mapper.Map<Aula>(aulaViewModel);
		_cursoRepository.AdicionarAula(aula);
		await _cursoRepository.UnitOfWork.Commit();
	}


	public void Dispose()
	{
		_cursoRepository?.Dispose();
	}
}
