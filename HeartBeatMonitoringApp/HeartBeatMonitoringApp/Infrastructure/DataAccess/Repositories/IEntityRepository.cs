using HeartBeatMonitoringApp.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HeartBeatMonitoringApp.Infrastructure.DataAccess.Repositories;

public interface IEntityRepository<TEntity>
    where TEntity : class, IEntity
{
    Task<TEntity> GetAsync(int id);

    Task AddAsync(TEntity entity);
    
    
    void Add(TEntity entity);

    Task UpdateAsync(int id, TEntity entity);

    Task DeleteAsync(int id);

    Task SaveAsync();
}