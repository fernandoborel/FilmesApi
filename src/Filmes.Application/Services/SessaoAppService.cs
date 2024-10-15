using AutoMapper;
using Filmes.Application.Commands.Sessao;
using Filmes.Application.Interfaces;
using Filmes.Domain.Entities;
using Filmes.Domain.Interfaces.Services;

namespace Filmes.Application.Services;

public class SessaoAppService : ISessaoAppService
{
    private readonly ISessaoDomainService _sessaoDomainService;
    private readonly IMapper _mapper;

    public SessaoAppService(ISessaoDomainService sessaoDomainService, IMapper mapper)
    {
        _sessaoDomainService = sessaoDomainService;
        _mapper = mapper;
    }

    public List<Sessao> BuscarTodos()
    {
        return _sessaoDomainService.BuscarTodos();
    }

    public void CriarSessao(CriarSessaoComand comand)
    {
        var sessao = _mapper.Map<Sessao>(comand);
        _sessaoDomainService.CriarSessao(sessao);
    }

    public void Dispose()
        => _sessaoDomainService?.Dispose();
}