using Filmes.Domain.Core;
using Filmes.Domain.Entities;

namespace Filmes.Domain.Interfaces.Repositories;

public interface IUsuarioRepository : IBaseRepository<Usuario, string>
{
    Usuario Get(string email);
    Usuario Get(string email, string senha);
}