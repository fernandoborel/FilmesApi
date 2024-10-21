using Filmes.Domain.Entities;

namespace Filmes.Domain.Interfaces.Services;

public interface IUsuarioDomainService : IDisposable
{
    AuthorizationModel AutenticarUsuario(string email, string senha);
    void CriarUsuario(Usuario usuario);
    Usuario BuscarPorId(int id);
    Usuario BuscarPorEmail(string email);
}
