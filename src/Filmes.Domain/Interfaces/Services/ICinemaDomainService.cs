using Filmes.Application.Commands.Cinema;
using Filmes.Domain.Entities;

namespace Filmes.Domain.Interfaces.Services;

public interface ICinemaDomainService : IDisposable
{
    void CriarCinema(CriarCinemaCommand command);
    List<Cinema> BuscarTodos();
}
