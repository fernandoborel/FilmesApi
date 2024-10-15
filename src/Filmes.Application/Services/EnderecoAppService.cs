using AutoMapper;
using Filmes.Application.Commands.Endereco;
using Filmes.Application.Interfaces;
using Filmes.Domain.Entities;
using Filmes.Domain.Interfaces.Services;

namespace Filmes.Application.Services;

public class EnderecoAppService : IEnderecoAppService
{
    private readonly IEnderecoDomainService _enderecoDomainService;
    private readonly IMapper _mapper;

    public EnderecoAppService(IEnderecoDomainService enderecoDomainService, IMapper mapper)
    {
        _enderecoDomainService = enderecoDomainService;
        _mapper = mapper;
    }

    public List<Endereco> BuscarEnderecos()
    {
        return _enderecoDomainService.BuscarTodos();
    }

    public void CriarEndereco(CriarEnderecoCommand command)
    {
        var endereco = _mapper.Map<Endereco>(command);
        _enderecoDomainService.CriarEndereco(endereco);
    }

    public void Dispose()    
        => _enderecoDomainService.Dispose();
}