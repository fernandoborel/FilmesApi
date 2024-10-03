using Filmes.Domain.Entities;
using Filmes.Domain.Interfaces.Repositories;
using Filmes.Domain.Interfaces.Services;

namespace Filmes.Domain.Services;

public class EnderecoDomainService : IEnderecoDomainService
{
    private readonly IEnderecoRepository _enderecoRepository;

    public EnderecoDomainService(IEnderecoRepository enderecoRepository)
    {
        _enderecoRepository = enderecoRepository;
    }

    public void CriarEndereco(Endereco endereco)
    {
        _enderecoRepository.Create(endereco);
    }

    public List<Endereco> BuscarTodos()
    {
        return _enderecoRepository.GetAll().ToList();
    }

    public void Dispose()
    {
        _enderecoRepository.Dispose();
    }
}
