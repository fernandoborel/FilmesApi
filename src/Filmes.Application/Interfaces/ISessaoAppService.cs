using Filmes.Application.Commands.Sessao;
using Filmes.Domain.Entities;

namespace Filmes.Application.Interfaces;

public interface ISessaoAppService : IDisposable
{
    void CriarSessao(CriarSessaoComand comand);
    List<Sessao> BuscarTodos();
}