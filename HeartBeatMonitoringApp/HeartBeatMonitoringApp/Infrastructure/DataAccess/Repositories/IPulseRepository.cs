using HeartBeatMonitoringApp.Infrastructure.Database.Entities;

namespace HeartBeatMonitoringApp.Infrastructure.DataAccess.Repositories;

public interface IPulseRepository : IEntityRepository<PulseRecord>
{
    Task<List<PulseRecord>> GetAllAsync(int userId);
}