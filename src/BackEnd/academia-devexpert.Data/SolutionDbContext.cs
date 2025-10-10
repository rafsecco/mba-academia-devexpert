using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace academia_devexpert.Data;

public class SolutionDbContext : DbContext
{
	public SolutionDbContext(DbContextOptions<SolutionDbContext> options) : base(options)
	{
		ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
		ChangeTracker.AutoDetectChangesEnabled = false;
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{

		//var isSqlite = Database.ProviderName.Contains("Microsoft.Data.Sqlite", StringComparison.OrdinalIgnoreCase);


		//// Set default string length for all string properties
		//foreach (var property in modelBuilder.Model.GetEntityTypes()
		//				.SelectMany(t => t.GetProperties())
		//				.Where(p => p.ClrType == typeof(string)))
		//{
		//	// Se for SQLite, usamos 'text' para grandes textos, e no SQL Server 'nvarchar(max)'
		//	if (isSqlite)
		//	{
		//		// Para SQLite, usamos 'text' em vez de 'nvarchar(max)'
		//		property.SetColumnType("TEXT");
		//	}
		//	else
		//	{
		//		// Para SQL Server, usamos 'nvarchar(max)' para grandes textos
		//		if (property.GetMaxLength() == null)
		//		{
		//			property.SetMaxLength(255); // Define um tamanho padrão
		//		}
		//	}

		//}

		modelBuilder.ApplyConfigurationsFromAssembly(typeof(SolutionDbContext).Assembly);

		// Set all foreign keys to have DeleteBehavior.ClientSetNull
		foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
		{
			relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
		}

		base.OnModelCreating(modelBuilder);
	}

	//public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
	//{
	//	foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
	//	{
	//		if (entry.State == EntityState.Added)
	//		{
	//			entry.Property("DataCadastro").CurrentValue = DateTime.Now;
	//		}
	//		if (entry.State == EntityState.Modified)
	//		{
	//			entry.Property("DataCadastro").IsModified = false;
	//		}
	//	}
	//	return base.SaveChangesAsync(cancellationToken);
	//}
}
