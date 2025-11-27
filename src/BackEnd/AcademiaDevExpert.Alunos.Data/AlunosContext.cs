using AcademiaDevExpert.Core.Data;
using AcademiaDevExpert.Alunos.Domain;
using Microsoft.EntityFrameworkCore;

namespace AcademiaDevExpert.Alunos.Data;

public class AlunosContext : DbContext, IUnitOfWork
{

	public AlunosContext(DbContextOptions<AlunosContext> options) : base(options)
	{
	}

	public DbSet<Aluno> Alunos { get; set; }
	public DbSet<Matricula> Matriculas { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		foreach (var property in modelBuilder.Model.GetEntityTypes()
						.SelectMany(e => e.GetProperties()
						.Where(p => p.ClrType == typeof(string))))
			property.SetColumnType("varchar(100)");

		modelBuilder.ApplyConfigurationsFromAssembly(typeof(AlunosContext).Assembly);
	}

	public async Task<bool> Commit()
	{
		foreach (var entity in ChangeTracker.Entries().Where(e => e.Entity.GetType().GetProperty("CriadoEm") != null))
		{
			if (entity.State == EntityState.Added)
			{
				entity.Property("CriadoEm").CurrentValue = DateTime.Now;
			}
			if (entity.State == EntityState.Modified)
			{
				entity.Property("CriadoEm").IsModified = false;
			}
		}

		return await base.SaveChangesAsync() > 0;
	}
}
