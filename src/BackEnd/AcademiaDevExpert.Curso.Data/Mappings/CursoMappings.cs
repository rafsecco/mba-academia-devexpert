using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaDevExpert.Curso.Data.Mappings;

public class CursoMappings : IEntityTypeConfiguration<Domain.Curso>
{
	public void Configure(EntityTypeBuilder<Domain.Curso> builder)
	{
		builder.ToTable("tb_Cursos");
		builder.HasKey(c => c.Id);

		builder.Property(p => p.Titulo)
			.IsRequired()
			.HasMaxLength(100);
		builder.Property(p => p.Descricao)
			.IsRequired()
			.HasMaxLength(300);
		builder.Property(p => p.Ativo)
			.HasDefaultValue(true);
		builder.Property(c => c.Imagem)
			.HasMaxLength(250);

		// 1 : N => Curso : Aulas
		builder.HasMany(c => c.Aulas)
			.WithOne(a => a.Curso)
			.HasForeignKey(a => a.CursoId);
	}
}
