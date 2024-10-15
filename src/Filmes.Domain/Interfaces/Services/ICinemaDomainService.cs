using Filmes.Domain.Entities;

namespace Filmes.Domain.Interfaces.Services;

public interface ICinemaDomainService : IDisposable
{
    void CriarCinema(Cinema cinema);
    List<Cinema> BuscarTodos();
}