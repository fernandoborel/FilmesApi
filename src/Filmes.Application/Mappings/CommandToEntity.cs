using AutoMapper;
using Filmes.Application.Commands.Cinema;
using Filmes.Application.Commands.Endereco;
using Filmes.Application.Commands.Filme;
using Filmes.Application.Commands.Sessao;
using Filmes.Application.Commands.Usuario;
using Filmes.Domain.Entities;

namespace Filmes.Domain.Mappings;

public class CommandToEntity : Profile
{
    public CommandToEntity()
    {
        #region Cinema

        CreateMap<CriarCinemaCommand, Cinema>().ReverseMap();

        #endregion

        #region Endereco

        CreateMap<CriarEnderecoCommand, Endereco>().ReverseMap();

        #endregion

        #region Filme

        CreateMap<CriarFilmeCommand, Filme>().ReverseMap();
        CreateMap<AtualizarFilmeCommand, Filme>().ReverseMap();
        CreateMap<BuscarFilmeCommand, Filme>().ReverseMap();
        CreateMap<DeletarFilmeCommand, Filme>().ReverseMap();

        #endregion

        #region Endereco

        CreateMap<CriarSessaoComand, Sessao>().ReverseMap();

        #endregion

        #region Usuario

        CreateMap<CriarUsuarioCommand, Usuario>().ReverseMap();

        #endregion
    }
}