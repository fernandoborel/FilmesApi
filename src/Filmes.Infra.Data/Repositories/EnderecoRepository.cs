using Filmes.Domain.Entities;
using Filmes.Domain.Interfaces.Repositories;
using Filmes.Infra.Data.Context;

namespace Filmes.Infra.Data.Repositories;

public class EnderecoRepository : BaseRepository<Endereco, int>, IEnderecoRepository
{
    private readonly SqlServerContext _context;

    public EnderecoRepository(SqlServerContext context) : base(context)
        => _context = context;    
}