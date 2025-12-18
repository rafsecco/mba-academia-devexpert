using AcademiaDevExpert.Core.Data;
using AcademiaDevExpert.Financeiro.Business;

namespace AcademiaDevExpert.Financeiro.Data.Repository;

public class PagamentoRepository : IPagamentoRepository
{
	private readonly PagamentosContext _context;

	public PagamentoRepository(PagamentosContext context)
	{
		_context = context;
	}

	public IUnitOfWork UnitOfWork => _context;

	public void Adicionar(Pagamento pagamento)
	{
		_context.Pagamentos.Add(pagamento);
	}

	public void AdicionarTransacao(Transacao transacao)
	{
		_context.Transacoes.Add(transacao);
	}

	public void Dispose()
	{
		_context.Dispose();
	}
}
