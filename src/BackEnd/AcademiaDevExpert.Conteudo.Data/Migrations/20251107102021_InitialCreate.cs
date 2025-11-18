using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademiaDevExpert.Conteudo.Data.Migrations
{
	/// <inheritdoc />
	public partial class InitialCreate : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "tb_Cursos",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Titulo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
					Descricao = table.Column<string>(type: "varchar(100)", maxLength: 300, nullable: false),
					Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
					Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					Imagem = table.Column<string>(type: "varchar(100)", maxLength: 250, nullable: false),
					CargaHoraria = table.Column<TimeSpan>(type: "time", nullable: false),
					ConteudoProgramatico_Titulo = table.Column<string>(type: "varchar(100)", nullable: false),
					ConteudoProgramatico_Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
					CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_tb_Cursos", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "tb_Aulas",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Titulo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
					Descricao = table.Column<string>(type: "varchar(100)", maxLength: 500, nullable: false),
					Duracao = table.Column<TimeSpan>(type: "time", nullable: false),
					CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_tb_Aulas", x => x.Id);
					table.ForeignKey(
						name: "FK_tb_Aulas_tb_Cursos_CursoId",
						column: x => x.CursoId,
						principalTable: "tb_Cursos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_tb_Aulas_CursoId",
				table: "tb_Aulas",
				column: "CursoId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "tb_Aulas");

			migrationBuilder.DropTable(
				name: "tb_Cursos");
		}
	}
}
