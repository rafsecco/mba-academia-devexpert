using AcademiaDevExpert.Core.Data;

namespace AcademiaDevExpert.Financeiro.Business;

public interface IPagamentoRepository : IRepository<Pagamento>
{
	void Adicionar(Pagamento pagamento);
	void AdicionarTransacao(Transacao transacao);
}
