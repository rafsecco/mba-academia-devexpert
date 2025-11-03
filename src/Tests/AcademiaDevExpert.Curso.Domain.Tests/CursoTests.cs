using AcademiaDevExpert.Core.DomainObjects;

namespace AcademiaDevExpert.Curso.Domain.Tests;

public class CursoTests
{
	[Fact]
	public void Curso_Validar_ValidacoesDevemRetornarExceptions()
	{
		// Arrange & Act & Assert

		var ex = Assert.Throws<DomainException>(static () =>
			new Curso(string.Empty, "Descrição", false, 100, "Imagem", new ConteudoProgramatico("Conteudo 1", "Descrição conteudo"))
		);
		Assert.Equal("O título do curso não pode estar vazio", ex.Message);

		ex = Assert.Throws<DomainException>(() =>
			new Curso("Título", string.Empty, false, 100, "Imagem", new ConteudoProgramatico("Conteudo 1", "Descrição conteudo"))
		);
		Assert.Equal("A descrição do curso não pode estar vazia", ex.Message);

		ex = Assert.Throws<DomainException>(() =>
			new Curso("Título", "Descrição", false, valor: -1, "Imagem", new ConteudoProgramatico("Conteudo 1", "Descrição conteudo"))
		);
		Assert.Equal("O valor do curso não pode ser negativo", ex.Message);

		ex = Assert.Throws<DomainException>(() =>
			new Curso("Título", "Descrição", false, 100, string.Empty, new ConteudoProgramatico("Conteudo 1", "Descrição conteudo"))
		);
		Assert.Equal("A imagem do curso não pode estar vazia", ex.Message);

		ex = Assert.Throws<DomainException>(() =>
			new Curso("Título", "Descrição", false, 100, "Imagem", new ConteudoProgramatico(string.Empty, "Descrição conteudo"))
		);
		Assert.Equal("O Título do conteúdo programático não pode estar vazio", ex.Message);

		ex = Assert.Throws<DomainException>(() =>
			new Curso("Título", "Descrição", false, 100, "Imagem", new ConteudoProgramatico("Conteudo 1", string.Empty))
		);
		Assert.Equal("A Descrição do conteúdo programático não pode estar vazio", ex.Message);
	}
}
