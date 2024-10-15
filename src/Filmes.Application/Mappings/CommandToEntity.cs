using AutoMapper;
using Filmes.Application.Commands.Cinema;
using Filmes.Application.Commands.Endereco;
using Filmes.Application.Commands.Filme;
using Filmes.Application.Commands.Sessao;
using Filmes.Domain.Entities;

namespace Filmes.Domain.Mappings;

public class CommandToEntity : Profile
{
    public CommandToEntity()
    {
        CreateMap<CriarCinemaCommand, Cinema>().ReverseMap();
        CreateMap<CriarEnderecoCommand, Endereco>().ReverseMap();
        CreateMap<CriarFilmeCommand, Filme>().ReverseMap();
        CreateMap<AtualizarFilmeCommand, Filme>().ReverseMap();
        CreateMap<BuscarFilmeCommand, Filme>().ReverseMap();
        CreateMap<CriarSessaoComand, Sessao>().ReverseMap();
        CreateMap<DeletarFilmeCommand, Filme>().ReverseMap();
    }
}