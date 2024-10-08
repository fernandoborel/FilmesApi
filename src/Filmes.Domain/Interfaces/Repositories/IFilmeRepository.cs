using Filmes.Domain.Core;
using Filmes.Domain.Entities;

namespace Filmes.Domain.Interfaces.Repositories;

public interface IFilmeRepository : IBaseRepository<Filme, string>
{
    Filme GetByName(string name);
}