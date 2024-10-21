using Filmes.Domain.Entities;
using Filmes.Domain.Interfaces.Repositories;
using Filmes.Domain.Interfaces.Security;
using Filmes.Domain.Interfaces.Services;

namespace Filmes.Domain.Services;

public class UsuarioDomainService : IUsuarioDomainService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IAuthorizationSecurity _authorizationSecurity;

    public UsuarioDomainService(IUsuarioRepository usuarioRepository, IAuthorizationSecurity authorizationSecurity)
    {
        _usuarioRepository = usuarioRepository;
        _authorizationSecurity = authorizationSecurity;
    }
    public void CriarUsuario(Usuario usuario)
    {
        _usuarioRepository.Create(usuario);
    }

    public Usuario BuscarPorEmail(string email)
    {
        var mail = _usuarioRepository.Get(email);
        return mail;
    }

    public Usuario BuscarPorId(int id)
    {
        var usuario = _usuarioRepository.GetById(id);
        return usuario;
    }

    public AuthorizationModel AutenticarUsuario(string email, string senha)
    {
        var user = _usuarioRepository.Get(email, senha);

        if (user != null)
            return new AuthorizationModel
            {
                IdUsuario = user.IdUsuario,
                Nome = user.Nome,
                Email = user.Email,
                AccessToken = _authorizationSecurity.CreateToken(user)
            };

        throw new Exception("Usuário ou senha inválidos");
    }

    public void Dispose()
    {
        _usuarioRepository.Dispose();
    }
}
