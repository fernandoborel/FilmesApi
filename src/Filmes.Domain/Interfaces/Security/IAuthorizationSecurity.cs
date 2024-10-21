using Filmes.Domain.Entities;

namespace Filmes.Domain.Interfaces.Security;

public interface IAuthorizationSecurity
{
    string CreateToken(Usuario usuario);
}