using AcademiaDevExpert.Core.Communication.Mediator;
using AcademiaDevExpert.Core.Data;
using AcademiaDevExpert.Core.Messages;
using AcademiaDevExpert.Financeiro.Business;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AcademiaDevExpert.Financeiro.Data;

public class PagamentosContext : DbContext, IUnitOfWork
{
	private readonly IMediatorHandler _mediatorHandler;

	public DbSet<Pagamento> Pagamentos { get; set; }
	public DbSet<Transacao> Transacoes { get; set; }

	public PagamentosContext(DbContextOptions<PagamentosContext> options, IMediatorHandler rebusHandler)
		: base(options)
	{
		_mediatorHandler = rebusHandler ?? throw new ArgumentNullException(nameof(rebusHandler));
	}

	public async Task<bool> Commit()
	{
		var sucesso = await base.SaveChangesAsync() > 0;
		if (sucesso) await _mediatorHandler.PublicarEventos(this);

		return sucesso;
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		modelBuilder.Ignore<Event>();

		foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
					 e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
			property.SetColumnType("varchar(100)");

		foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
			relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

		base.OnModelCreating(modelBuilder);
	}
}
