using Filmes.Application.Commands.Cinema;
using Filmes.Domain.Entities;

namespace Filmes.Application.Interfaces;

public interface ICinemaAppService : IDisposable
{
    void CriarCinema(CriarCinemaCommand command);
    List<Cinema> BuscarCinemas();
}