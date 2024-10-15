using Filmes.Domain.Core;
using Filmes.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Filmes.Infra.Data.Repositories;

public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
    where TEntity : class
{

    private readonly SqlServerContext _context;

    protected BaseRepository(SqlServerContext context)
        => _context = context;    

    public virtual void Create(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Added;
        _context.SaveChanges();
    }

    public virtual void Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public virtual void Delete(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Deleted;
        _context.SaveChanges();
    }

    public virtual List<TEntity> GetAll()
    {
        return _context.Set<TEntity>().ToList();
    }

    public virtual TEntity GetById(int id)
    {
        return _context.Set<TEntity>().Find(id);
    }

    public void Dispose()
        => _context?.Dispose();
}