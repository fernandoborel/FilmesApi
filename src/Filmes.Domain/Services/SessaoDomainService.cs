using Filmes.Domain.Entities;
using Filmes.Domain.Interfaces.Repositories;
using Filmes.Domain.Interfaces.Services;

namespace Filmes.Domain.Services;

public class SessaoDomainService : ISessaoDomainService
{
    private readonly ISessaoRepository _repository;

    public SessaoDomainService(ISessaoRepository repository)
       => _repository = repository;

    public List<Sessao> BuscarTodos()
    {
        return _repository.GetAll();
    }

    public void CriarSessao(Sessao sessao)
    {
        _repository.Create(sessao);
    }

    public void Dispose()
        => _repository?.Dispose();
}