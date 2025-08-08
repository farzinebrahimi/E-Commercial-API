using Eshop.Data.Context;
using Eshop.Data.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Data.Repository;

public class GenericRepository<TEntity>(
  ApplicationDbContext dbContext,
  DbSet<TEntity> dbSet
)
  : IGenericRepository<TEntity>
  where TEntity : BaseEntity
{
  

  public async ValueTask DisposeAsync()
  {
    await dbContext.DisposeAsync();
  }

  public IQueryable<TEntity> GetQuery()
  {
    return dbSet.AsQueryable();  
  }

  public async Task<TEntity> GetByIdAsync(long id)
  {
    return await dbSet.SingleOrDefaultAsync(d => d.Id == id);
  }

  public async Task AddEntity(TEntity entity)
  {
    entity.CreateDate = DateTime.UtcNow;
    entity.LastUpdateDate = DateTime.UtcNow;
    
    await dbSet.AddAsync(entity);
  }

  public async Task AddRangeEntities(List<TEntity> entities)
  {
    foreach (var entity in entities)
    {
      entity.CreateDate = DateTime.UtcNow;
      entity.LastUpdateDate = DateTime.UtcNow;
      await dbSet.AddAsync(entity);
    }
  }

  public void UpdateEntity(TEntity entity)
  {
    entity.LastUpdateDate = DateTime.UtcNow;
    dbSet.Update(entity);
  }

  public void DeleteEntity(TEntity entity)
  {
    entity.IsDeleted = true;
    UpdateEntity(entity);
  }

  public void DeleteEntities(List<TEntity> entities)
  {
    foreach (var entity in entities)
    {
      entity.IsDeleted = true;
      UpdateEntity(entity);
    }
  }

  public async Task DeletePermanently(TEntity entity)
  {
    dbSet.Remove(entity);
  }

  public async Task SaveChangesAsync()
  {
    await dbContext.SaveChangesAsync();
  }
}