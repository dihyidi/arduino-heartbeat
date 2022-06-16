using System.Linq.Expressions;
using HeartBeatMonitoringApp.Infrastructure.Database.Entities;

namespace HeartBeatMonitoringApp.Infrastructure.DataAccess.Repositories;

public interface IUserRepository : IEntityRepository<UserEntity>
{
    Task<bool> AnyAsync(Expression<Func<UserEntity, bool>> predicate);
}