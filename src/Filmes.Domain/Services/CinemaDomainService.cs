using AutoMapper;
using Filmes.Application.Commands.Cinema;
using Filmes.Domain.Entities;
using Filmes.Domain.Interfaces.Repositories;
using Filmes.Domain.Interfaces.Services;

namespace Filmes.Domain.Services;

public class CinemaDomainService : ICinemaDomainService
{
    private readonly ICinemaRepository _cinemaRepository;
    private readonly IMapper _mapper;

    public CinemaDomainService(ICinemaRepository cinemaRepository, IMapper mapper)
    {
        _cinemaRepository = cinemaRepository;
        _mapper = mapper;
    }

    public List<Cinema> BuscarTodos()
    {
        return _cinemaRepository.GetAll().ToList();
    }

    public void CriarCinema(CriarCinemaCommand command)
    {
        var cinema = _mapper.Map<Cinema>(command);
        _cinemaRepository.Create(cinema);
    }


    public void Dispose()
    {
        _cinemaRepository?.Dispose();
    }
}
