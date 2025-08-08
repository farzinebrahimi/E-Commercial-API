using Eshop.Data.Entities.Common;

namespace Eshop.Data.Repository
{
  public interface IGenericRepository<TEntity> : IAsyncDisposable where TEntity : BaseEntity
  {
    IQueryable<TEntity> GetQuery();
    Task<TEntity> GetByIdAsync(long id);
    Task AddEntity(TEntity entity);
    Task AddRangeEntities(List<TEntity> entities);
    void UpdateEntity(TEntity entity);
    void DeleteEntity(TEntity entity);
    void DeleteEntities(List<TEntity> entities);
    Task DeletePermanently(TEntity entity);
    Task SaveChangesAsync();
  }
}