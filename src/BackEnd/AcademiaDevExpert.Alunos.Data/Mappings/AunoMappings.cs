using AcademiaDevExpert.Alunos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaDevExpert.Alunos.Data.Mappings;

public class AunoMappings : IEntityTypeConfiguration<Aluno>
{
	public void Configure(EntityTypeBuilder<Aluno> builder)
	{
		builder.ToTable("tb_Alunos");
		builder.HasKey(c => c.Id);

		builder.Property(p => p.Nome)
			.IsRequired()
			.HasMaxLength(150);

		builder.Property(p => p.SobreNome)
			.IsRequired()
			.HasMaxLength(150);

		builder.Property(p => p.Email)
			.IsRequired()
			.HasMaxLength(255);
	}
}
