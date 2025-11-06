using AcademiaDevExpert.Conteudo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaDevExpert.Conteudo.Data.Mappings;

public class AulaMappings : IEntityTypeConfiguration<Domain.Aula>
{
	public void Configure(EntityTypeBuilder<Aula> builder)
	{
		builder.ToTable("tb_Aulas");
		builder.HasKey(c => c.Id);

		builder.Property(p => p.Titulo)
			.IsRequired()
			.HasMaxLength(100);
		builder.Property(p => p.Descricao)
			.IsRequired()
			.HasMaxLength(500);
		builder.Property(p => p.Duracao)
			.IsRequired();
	}
}
