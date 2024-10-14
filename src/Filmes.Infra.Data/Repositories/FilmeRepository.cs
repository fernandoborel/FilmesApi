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

    public Filme GetById(int id)
    {
        return _context.Filme.Find(id);
    }

    public Filme UpdateFilme(Filme filme)
    {
        var id = _context.Filme.Find(filme.IdFilme);

        if (id != null)
        {
            _context.Filme.Update(filme);
            _context.SaveChanges();
            return filme;
        }

        return null;
    }
}
