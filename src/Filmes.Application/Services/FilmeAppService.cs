using AutoMapper;
using Filmes.Application.Commands.Filme;
using Filmes.Application.Interfaces;
using Filmes.Domain.Entities;
using Filmes.Domain.Interfaces.Services;

namespace Filmes.Application.Services;

public class FilmeAppService : IFilmeAppService
{
    private readonly IFilmeDomainService _filmeDomainService;
    private readonly IMapper _mapper;

    public FilmeAppService(IFilmeDomainService filmeDomainService, IMapper mapper)
    {
        _filmeDomainService = filmeDomainService;
        _mapper = mapper;
    }

    public void BuscarFilmePeloNome(Filme filme)
    {
       _filmeDomainService.BuscarFilmePeloNome(filme);
    }

    public List<Filme> BuscarFilmes()
    {
        return _filmeDomainService.BuscarFilmes();
    }

    public void CriarFilme(CriarFilmeCommand command)
    {
        var filme = _mapper.Map<Filme>(command);
        _filmeDomainService.CriarFilme(filme);
    }

    public void Dispose()
    {
        _filmeDomainService?.Dispose();
    }
}
