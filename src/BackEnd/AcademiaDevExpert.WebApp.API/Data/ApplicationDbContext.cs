using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AcademiaDevExpert.WebApp.API.Data;

public class ApplicationDbContext : IdentityDbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		base.OnModelCreating(builder);

		//HACK: pra auto incremento no Sqlite para a tabela AspNetRoleClaims
		builder.Entity<IdentityRoleClaim<string>>(b =>
		{
			b.Property<int>("Id")
				.ValueGeneratedOnAdd()
				.HasColumnType("INTEGER"); // Ajuste para garantir auto-incremento no SQLite
		});

		//HACK: pra não setar string como varchar(max)
		foreach (var entityType in builder.Model.GetEntityTypes())
		{
			foreach (var property in entityType.GetProperties())
			{
				if (property.ClrType == typeof(string) && property.GetColumnType() == null)
				{
					property.SetColumnType("varchar(1000)");
				}
			}
		}
	}
}
