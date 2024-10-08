using Filmes.Domain.Entities;
using Filmes.Domain.Interfaces.Repositories;
using Filmes.Infra.Data.Context;

namespace Filmes.Infra.Data.Repositories;

public class FilmeRepository : BaseRepository<Filme, string>, IFilmeRepository
{
    private readonly SqlServerContext _context;

    public FilmeRepository(SqlServerContext context) : base(context)
    {
        _context = context;
    }

    public Filme GetByName(string name)
    {
        return _context.Filme
            .FirstOrDefault(f=> f.Titulo.ToLower().Contains(name.ToLower()));
    }
}
