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
        var filmeExistente = _context.Filme.Find(filme.IdFilme);

        if (filmeExistente != null)
        {
            _context.Entry(filmeExistente).CurrentValues.SetValues(filme);
            _context.SaveChanges();
            return filmeExistente;
        }

        return null;
    }

    public Filme DeletarFilme(int id)
    {
        var filme = _context.Filme.Find(id);

        if (filme != null)
        {
            _context.Filme.Remove(filme);
            _context.SaveChanges();
            return filme;
        }

        return null;
    }
}
