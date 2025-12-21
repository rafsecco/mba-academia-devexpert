
using AcademiaDevExpert.Core.Communication.Mediator;
using AcademiaDevExpert.Core.Messages.CommonMessages.IntegrationEvents;
using AcademiaDevExpert.Core.Messages.CommonMessages.Notifications;

namespace AcademiaDevExpert.Financeiro.Business;

public class PagamentoService : IPagamentoService
{
	private readonly IPagamentoRepository _pagamentoRepository;
	private readonly IPagamentoCartaoCreditoFacade _pagamentoCartaoCreditoFacade;
	private readonly IMediatorHandler _mediatorHandler;

	public PagamentoService(
		IPagamentoRepository pagamentoRepository,
		IPagamentoCartaoCreditoFacade pagamentoCartaoCreditoFacade,
		IMediatorHandler mediatorHandler)
	{
		_pagamentoRepository = pagamentoRepository;
		_pagamentoCartaoCreditoFacade = pagamentoCartaoCreditoFacade;
		_mediatorHandler = mediatorHandler;
	}

	public async Task<Transacao> PagarMatricula(PagamentoMatricula pagamentoMatricula)
	{
		var pagamento = new Pagamento
		{
			MatriculaId = pagamentoMatricula.MatriculaId,
			Valor = pagamentoMatricula.Valor,
			DadosCartao = new CartaoCredito
			{
				Nome = pagamentoMatricula.NomeCartao,
				Numero = pagamentoMatricula.NumeroCartao,
				Expiracao = pagamentoMatricula.ExpiracaoCartao,
				CVV = pagamentoMatricula.CvvCartao
			}
		};

		var transacao = _pagamentoCartaoCreditoFacade.RealizarPagamento(pagamento);

		if (transacao.StatusTransacao == EnumStatusTransacao.Pago)
		{
			var pagEvent = new PagamentoRealizadoEvent(
				pagamento.MatriculaId,
				pagamentoMatricula.AlunoId,
				transacao.PagamentoId,
				transacao.Id,
				pagamentoMatricula.Valor);
			pagamento.AdicionarEvento(pagEvent);

			_pagamentoRepository.Adicionar(pagamento);
			_pagamentoRepository.AdicionarTransacao(transacao);

			await _pagamentoRepository.UnitOfWork.Commit();
			return transacao;
		}

		await _mediatorHandler.PublicarNotificacao(new DomainNotification("pagamento", "A operadora recusou o pagamento"));
		await _mediatorHandler.PublicarEvento(new PagamentoRecusadoEvent(pagamento.MatriculaId, pagamentoMatricula.AlunoId, transacao.PagamentoId, transacao.Id, pagamentoMatricula.Valor));

		return transacao;
	}
}
