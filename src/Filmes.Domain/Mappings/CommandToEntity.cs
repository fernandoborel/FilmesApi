using AutoMapper;
using Filmes.Application.Commands.Cinema;
using Filmes.Domain.Entities;

namespace Filmes.Domain.Mappings;

public class CommandToEntity : Profile
{
    public CommandToEntity()
    {
         CreateMap<CriarCinemaCommand, Cinema>().ReverseMap();
    }
}
