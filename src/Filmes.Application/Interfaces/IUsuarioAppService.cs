using Filmes.Application.Commands.Usuario;
using Filmes.Domain.Entities;

namespace Filmes.Application.Interfaces;

public interface IUsuarioAppService : IDisposable
{
    void CriarUsuario(CriarUsuarioCommand commmand);
    Usuario ObterPorEmail(string email);
    Usuario ObterPorId(int id);
    AuthorizationModel AutenticarUsuario(AutenticarUsuarioCommand command);
}