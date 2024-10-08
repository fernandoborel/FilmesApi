using Filmes.Domain.Entities;
using Filmes.Domain.Interfaces.Repositories;
using Filmes.Infra.Data.Context;

namespace Filmes.Infra.Data.Repositories;

public class SessaoRepository : BaseRepository<Sessao, int>, ISessaoRepository
{
    private readonly SqlServerContext _context;

    public SessaoRepository(SqlServerContext context) : base(context)
    {
        _context = context;
    }
}
