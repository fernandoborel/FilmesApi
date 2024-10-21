using Filmes.Domain.Entities;
using Filmes.Domain.Interfaces.Repositories;
using Filmes.Infra.Data.Context;
using Filmes.Infra.Data.Utils;

namespace Filmes.Infra.Data.Repositories;

public class UsuarioRepository : BaseRepository<Usuario, string>, IUsuarioRepository
{
    private readonly SqlServerContext _context;

    public UsuarioRepository(SqlServerContext context) : base(context)
       => _context = context;


    public override void Create(Usuario usuario)
    {
        usuario.Senha = MD5Util.Get(usuario.Senha);
        base.Create(usuario);
    }

    public Usuario Get(string email)
    {
        return _context.Usuario.FirstOrDefault(u => u.Email == email);
    }

    public Usuario Get(string email, string senha)
    {
        senha = MD5Util.Get(senha);

        return _context.Usuario
            .FirstOrDefault(u => u.Email.Equals(email) && u.Senha.Equals(senha));
    }
}