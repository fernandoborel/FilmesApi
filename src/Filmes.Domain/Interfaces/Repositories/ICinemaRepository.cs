using Filmes.Domain.Core;
using Filmes.Domain.Entities;

namespace Filmes.Domain.Interfaces.Repositories;

public interface ICinemaRepository : IBaseRepository<Cinema, int>
{
    Cinema GetByName(string name);
}