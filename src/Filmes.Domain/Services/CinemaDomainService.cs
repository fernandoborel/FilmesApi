using Filmes.Domain.Entities;
using Filmes.Domain.Interfaces.Repositories;
using Filmes.Domain.Interfaces.Services;

namespace Filmes.Domain.Services;

public class CinemaDomainService : ICinemaDomainService
{
    private readonly ICinemaRepository _cinemaRepository;

    public CinemaDomainService(ICinemaRepository cinemaRepository)
    {
        _cinemaRepository = cinemaRepository;
    }

    public List<Cinema> BuscarTodos()
    {
        return _cinemaRepository.GetAll().ToList();
    }

    public void CriarCinema(Cinema cinema)
    {
        _cinemaRepository.Create(cinema);
    }

    public void Dispose()
    {
        _cinemaRepository?.Dispose();
    }
}
