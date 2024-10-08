using Filmes.Domain.Entities;

namespace Filmes.Domain.Interfaces.Services;

public interface ISessaoDomainService : IDisposable
{
    void CriarSessao(Sessao sessao);
    List<Sessao> BuscarTodos();
}