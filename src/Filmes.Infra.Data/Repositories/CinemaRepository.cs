using Filmes.Domain.Entities;
using Filmes.Domain.Interfaces.Repositories;
using Filmes.Infra.Data.Context;

namespace Filmes.Infra.Data.Repositories;

public class CinemaRepository : BaseRepository<Cinema, int>, ICinemaRepository
{
    private readonly SqlServerContext _context;

    public CinemaRepository(SqlServerContext context) : base(context)
       => _context = context;

    public Cinema GetByName(string name)
    {
        return _context.Cinema
            .FirstOrDefault(c => c.Nome.ToLower().Contains(name.ToLower()));
    }
}