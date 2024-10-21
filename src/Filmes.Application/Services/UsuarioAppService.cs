using AutoMapper;
using Filmes.Application.Commands.Usuario;
using Filmes.Application.Interfaces;
using Filmes.Domain.Entities;
using Filmes.Domain.Interfaces.Services;

namespace Filmes.Application.Services;

public class UsuarioAppService : IUsuarioAppService
{
    private readonly IUsuarioDomainService _usuarioDomainService;
    private readonly IMapper _mapper;

    public UsuarioAppService(IUsuarioDomainService usuarioDomainService, IMapper mapper)
    {
        _usuarioDomainService = usuarioDomainService;
        _mapper = mapper;
    }

    public AuthorizationModel AutenticarUsuario(AutenticarUsuarioCommand command)
    {
        return _usuarioDomainService.AutenticarUsuario(command.Email, command.Senha);
    }

    public void CriarUsuario(CriarUsuarioCommand commmand)
    {
        var mail = _usuarioDomainService.BuscarPorEmail(commmand.Email);
        if(mail != null)
            throw new Exception("Email já cadastrado");

        var usuario = _mapper.Map<Usuario>(commmand);
        _usuarioDomainService.CriarUsuario(usuario);
    }

    public void Dispose()
    {
        _usuarioDomainService.Dispose();
    }

    public Usuario ObterPorEmail(string email)
    {
        return _usuarioDomainService.BuscarPorEmail(email);
    }

    public Usuario ObterPorId(int id)
    {
        return _usuarioDomainService.BuscarPorId(id);
    }
}