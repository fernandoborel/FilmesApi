using AutoMapper;
using Filmes.Application.Commands.Cinema;
using Filmes.Application.Interfaces;
using Filmes.Domain.Entities;
using Filmes.Domain.Interfaces.Services;

namespace Filmes.Application.Services;

public class CinemaAppService : ICinemaAppService
{
    private readonly ICinemaDomainService _cinemaDomainService;
    private readonly IMapper _mapper;

    public CinemaAppService(ICinemaDomainService cinemaDomainService, IMapper mapper)
    {
        _cinemaDomainService = cinemaDomainService;
        _mapper = mapper;
    }

    public List<Cinema> BuscarCinemas()
    {
        return _cinemaDomainService.BuscarTodos().ToList();
    }

    public void CriarCinema(CriarCinemaCommand command)
    {
        var cinema = _mapper.Map<Cinema>(command);
        _cinemaDomainService.CriarCinema(cinema);
    }

    public void Dispose()
        => _cinemaDomainService.Dispose();
}