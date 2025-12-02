using AcademiaDevExpert.Alunos.Application.ViewModels;
using AcademiaDevExpert.Alunos.Domain;
using AcademiaDevExpert.Core.Communication.Mediator;
using AcademiaDevExpert.Core.Messages.CommonMessages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaDevExpert.WebApp.API.Controllers;

public class AlunosController : MainController
{
	private readonly IMediatorHandler _mediatorHandler;
	private readonly IAlunoRepository _alunoRepository;

	public AlunosController(
		IMediatorHandler mediatrHandler,
		INotificationHandler<DomainNotification> notifications,
		IAlunoRepository alunoRepository
	) : base(mediatrHandler, notifications)
	{
		_mediatorHandler = mediatrHandler;
		_alunoRepository = alunoRepository;
	}

	[HttpGet]
	[ProducesResponseType(typeof(List<AlunoViewModel>), StatusCodes.Status200OK)]
	public async Task<ActionResult> ObterTodos(CancellationToken cancellationToken)
	{
		var alunos = await _alunoRepository.ObterTodos();
		return Ok(alunos);
	}

	[HttpGet("{id}")]
	[ProducesResponseType(typeof(AlunoViewModel), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<AlunoViewModel>> ObterPorId(Guid id, CancellationToken cancellationToken)
	{
		var aluno = await _alunoRepository.ObterAlunoPorId(id);
		if (aluno == null)
		{
			return NotFound();
		}
		return Ok(aluno);
	}

	[HttpPost("{id}/{cursoId}")]
	[ProducesResponseType(StatusCodes.Status201Created)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult> AdicionarMatricula(Guid id, Guid cursoId, CancellationToken cancellationToken)
	{
		try
		{
			await _alunoRepository.AdicionarMatricula(id, cursoId);
			return StatusCode(StatusCodes.Status201Created);
		}
		catch (UnauthorizedAccessException ex)
		{
			return Unauthorized(new { message = ex.Message });
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex.Message });
		}
	}






















}
