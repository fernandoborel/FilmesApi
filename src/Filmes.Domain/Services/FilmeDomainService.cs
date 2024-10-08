using Filmes.Domain.Entities;
using Filmes.Domain.Interfaces.Repositories;
using Filmes.Domain.Interfaces.Services;

namespace Filmes.Domain.Services;

public class FilmeDomainService : IFilmeDomainService
{
    private readonly IFilmeRepository _filmeRepository;

    public FilmeDomainService(IFilmeRepository filmeRepository)
    {
        _filmeRepository = filmeRepository;
    }

    public void BuscarFilmePeloNome(Filme filme)
    {
        _filmeRepository.GetByName(filme.Titulo);
    }

    public List<Filme> BuscarFilmes()
    {
        return _filmeRepository.GetAll();
    }

    public void CriarFilme(Filme filme)
    {
        _filmeRepository.Create(filme);
    }

    public void Dispose()
    {
        _filmeRepository.Dispose();
    }
}
