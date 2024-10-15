namespace Filmes.Domain.Core;

public interface IBaseRepository<TEntity, TKey> : IDisposable where TEntity : class
{
    void Create(TEntity entity);
    void Delete(TEntity entity);
    void Update(TEntity entity);

    List<TEntity> GetAll();
    TEntity GetById(int id);
}