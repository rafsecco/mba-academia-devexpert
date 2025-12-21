using AcademiaDevExpert.Core.DomainObjects;

namespace AcademiaDevExpert.Financeiro.Business;

public class Pagamento : Entity, IAggregateRoot
{
	public Guid MatriculaId { get; set; }
	public string Status { get; set; }
	public decimal Valor { get; set; }
	public CartaoCredito DadosCartao { get; set; }

	// EF. Rel.
	public Transacao Transacao { get; set; }
}
