namespace AcademiaDevExpert.Financeiro.Business;

public interface IPagamentoService
{
	Task<Transacao> PagarMatricula(PagamentoMatricula pagamentoMatricula);
}
