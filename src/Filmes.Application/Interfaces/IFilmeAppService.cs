using Filmes.Application.Commands.Filme;
using Filmes.Domain.Entities;

namespace Filmes.Application.Interfaces;

public interface IFilmeAppService : IDisposable
{
    void CriarFilme(CriarFilmeCommand command);
    List<Filme> BuscarFilmes();
    void BuscarFilmePeloNome(Filme filme);
}
