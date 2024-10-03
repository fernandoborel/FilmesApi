using AutoMapper;
using Filmes.Application.Commands.Cinema;
using Filmes.Application.Commands.Endereco;
using Filmes.Domain.Entities;

namespace Filmes.Domain.Mappings;

public class CommandToEntity : Profile
{
    public CommandToEntity()
    {
        CreateMap<CriarCinemaCommand, Cinema>().ReverseMap();
        CreateMap<CriarEnderecoCommand, Endereco>().ReverseMap();
    }
}