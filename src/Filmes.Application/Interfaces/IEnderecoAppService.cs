using Filmes.Application.Commands.Endereco;
using Filmes.Domain.Entities;

namespace Filmes.Application.Interfaces;

public interface IEnderecoAppService : IDisposable
{
    void CriarEndereco(CriarEnderecoCommand command);
    List<Endereco> BuscarEnderecos();
}
