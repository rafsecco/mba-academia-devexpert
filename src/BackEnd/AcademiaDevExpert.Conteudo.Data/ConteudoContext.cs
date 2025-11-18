using AcademiaDevExpert.Conteudo.Domain;
using AcademiaDevExpert.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace AcademiaDevExpert.Conteudo.Data;

public class ConteudoContext : DbContext, IUnitOfWork
{
	public ConteudoContext(DbContextOptions<ConteudoContext> options) : base(options)
	{
	}

	public DbSet<Curso> Cursos { get; set; }
	public DbSet<Aula> Aulas { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		foreach (var property in modelBuilder.Model.GetEntityTypes()
						.SelectMany(e => e.GetProperties()
						.Where(p => p.ClrType == typeof(string))))
			property.SetColumnType("varchar(100)");

		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ConteudoContext).Assembly);
		//base.OnModelCreating(modelBuilder);
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
