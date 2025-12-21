using AcademiaDevExpert.Conteudo.Application.ViewModels;
using AcademiaDevExpert.Conteudo.Domain;
using AcademiaDevExpert.Core.Communication.Mediator;
using AcademiaDevExpert.Core.Messages.CommonMessages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaDevExpert.WebApp.API.Controllers;

public class ConteudoController : MainController
{
	private readonly IMediatorHandler _mediatorHandler;
	private readonly ICursoRepository _cursoRepository;

	public ConteudoController(
		IMediatorHandler mediatrHandler,
		INotificationHandler<DomainNotification> notifications,
		ICursoRepository cursoRepository
	) : base(mediatrHandler, notifications)
	{
		_mediatorHandler = mediatrHandler;
		_cursoRepository = cursoRepository;
	}

	[HttpGet("curso")]
	[ProducesResponseType(typeof(IEnumerable<CursoViewModel>), StatusCodes.Status200OK)]
	public async Task<ActionResult> ObterTodos(CancellationToken cancellationToken)
	{
		var cursos = await _cursoRepository.ObterTodos();
		return Ok(cursos);
	}

	[HttpGet("curso/{id}")]
	[ProducesResponseType(typeof(CursoViewModel), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<CursoViewModel>> ObterPorId(Guid id, CancellationToken cancellationToken)
	{
		var aluno = await _cursoRepository.ObterPorId(id);
		if (aluno == null)
		{
			return NotFound();
		}
		return Ok(aluno);
	}

	[HttpGet("curso-aulas/{id}")]
	[ProducesResponseType(typeof(IEnumerable<AulaViewModel>), StatusCodes.Status200OK)]
	public async Task<ActionResult> ObterTodasAulas(Guid id, CancellationToken cancellationToken)
	{
		var aulas = await _cursoRepository.ObterTodasAulas(id);
		return Ok(aulas);
	}

	[HttpGet("curso-aula/{id}")]
	[ProducesResponseType(typeof(CursoViewModel), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<AulaViewModel>> ObterAula(Guid id, CancellationToken cancellationToken)
	{
		var aula = await _cursoRepository.ObterAula(id);
		if (aula == null)
		{
			return NotFound();
		}
		return Ok(aula);
	}
}
