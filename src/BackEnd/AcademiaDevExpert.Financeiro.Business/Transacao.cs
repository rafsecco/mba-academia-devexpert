using AcademiaDevExpert.Core.DomainObjects;

namespace AcademiaDevExpert.Financeiro.Business;

public class Transacao : Entity
{
	public Guid MatriculaId { get; set; }
	public Guid PagamentoId { get; set; }
	public decimal Total { get; set; }
	public EnumStatusTransacao StatusTransacao { get; set; }

	// EF. Rel.
	public Pagamento Pagamento { get; set; }
}
