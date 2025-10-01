using Microsoft.EntityFrameworkCore;

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
		// Set default string length for all string properties
		foreach (var property in modelBuilder.Model.GetEntityTypes()
						.SelectMany(t => t.GetProperties())
						.Where(p => p.ClrType == typeof(string)))
		{
			if (property.GetMaxLength() == null)
			{
				property.SetMaxLength(255);
			}
		}

		modelBuilder.ApplyConfigurationsFromAssembly(typeof(SolutionDbContext).Assembly);

		// Set all foreign keys to have DeleteBehavior.ClientSetNull
		foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
		{
			relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
		}

		base.OnModelCreating(modelBuilder);
	}

	public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
	{
		foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
		{
			if (entry.State == EntityState.Added)
			{
				entry.Property("DataCadastro").CurrentValue = DateTime.Now;
			}
			if (entry.State == EntityState.Modified)
			{
				entry.Property("DataCadastro").IsModified = false;
			}
		}
		return base.SaveChangesAsync(cancellationToken);
	}
}
