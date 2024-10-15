using Filmes.Domain.Entities;

namespace Filmes.Domain.Interfaces.Services;

public interface IFilmeDomainService : IDisposable
{
    void CriarFilme(Filme filme);
    void BuscarFilmePeloNome(Filme filme);
    List<Filme> BuscarFilmes();
    Filme BuscarFilmePeloId(int id);
    Filme AtualizarFilme(int id);
}
