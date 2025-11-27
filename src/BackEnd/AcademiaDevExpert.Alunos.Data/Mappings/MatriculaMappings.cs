using AcademiaDevExpert.Alunos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaDevExpert.Alunos.Data.Mappings;

internal class MatriculaMappings : IEntityTypeConfiguration<Matricula>
{
	public void Configure(EntityTypeBuilder<Matricula> builder)
	{
		builder.ToTable("tb_Matriculas");
		builder.HasKey(m => m.Id);

		builder.Property(m => m.AlunoId)
			.IsRequired()
			.HasMaxLength(100);
		builder.Property(m => m.CursoId)
			.IsRequired()
			.HasMaxLength(100);


		builder.HasOne(m => m.Aluno)
			.WithMany()
			.HasForeignKey(fk => fk.AlunoId);
	}
}
