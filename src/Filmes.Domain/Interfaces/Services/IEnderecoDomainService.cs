using Filmes.Domain.Entities;

namespace Filmes.Domain.Interfaces.Services;

public interface IEnderecoDomainService : IDisposable
{
    void CriarEndereco(Endereco endereco);
    List<Endereco> BuscarTodos();
}