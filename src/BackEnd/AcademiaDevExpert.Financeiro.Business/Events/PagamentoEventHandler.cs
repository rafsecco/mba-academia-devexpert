using AcademiaDevExpert.Core.Messages.CommonMessages.IntegrationEvents;
using MediatR;

namespace AcademiaDevExpert.Financeiro.Business.Events;

public class PagamentoEventHandler : INotificationHandler<MatriculaConfirmadaEvent>
{
	private readonly IPagamentoService _pagamentoService;

	public PagamentoEventHandler(IPagamentoService pagamentoService)
	{
		_pagamentoService = pagamentoService;
	}

	public async Task Handle(MatriculaConfirmadaEvent evento, CancellationToken cancellationToken)
	{
		var pagamentoMatricula = new PagamentoMatricula
		{
			AlunoId = evento.AlunoId,
			CursoId = evento.CursoId,
			MatriculaId = evento.MatriculaId,
			Valor = evento.Valor,
			NomeCartao = evento.NomeCartao,
			NumeroCartao = evento.NumeroCartao,
			ExpiracaoCartao = evento.ExpiracaoCartao,
			CvvCartao = evento.CvvCartao
		};

		await _pagamentoService.PagarMatricula(pagamentoMatricula);
	}
}

