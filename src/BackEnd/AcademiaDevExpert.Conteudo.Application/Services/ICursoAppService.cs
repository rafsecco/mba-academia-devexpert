using AcademiaDevExpert.Conteudo.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaDevExpert.Conteudo.Application.Services;

public interface ICursoAppService : IDisposable
{
	Task<IEnumerable<CursoViewModel>> ObterTodos();
	Task<CursoViewModel> ObterPorId(Guid id);
	Task Adicionar(CursoViewModel cursoViewModel);
	Task Atualizar(CursoViewModel cursoViewModel);


	Task<IEnumerable<AulaViewModel>> ObterTodasAulas(Guid cursoId);
	Task<AulaViewModel> ObterAula(Guid aulaId);
	Task AdicionarAula(AulaViewModel aulaViewModel);
}
