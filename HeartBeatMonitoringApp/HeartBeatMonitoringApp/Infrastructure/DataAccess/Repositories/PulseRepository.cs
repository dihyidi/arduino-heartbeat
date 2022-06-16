using HeartBeatMonitoringApp.Infrastructure.Database;
using HeartBeatMonitoringApp.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace HeartBeatMonitoringApp.Infrastructure.DataAccess.Repositories;

public class PulseRepository : IPulseRepository
{
    private readonly HeartBeatMonitoringAppDbContext context;

    public PulseRepository(HeartBeatMonitoringAppDbContextFactory contextFactory)
    {
        this.context = contextFactory.CreateDbContext(new string[1]);
    }

    public Task<List<PulseRecord>> GetAllAsync(int userId)
    {
        return context.PulseRecords.Where(x => x.UserId == userId).ToListAsync();
    }

    public Task<PulseRecord> GetAsync(int id)
    {
        return context.PulseRecords.FirstAsync(x => x.Id == id);
    }

    public async Task AddAsync(PulseRecord entity)
    {
        await context.PulseRecords.AddAsync(entity);
        await this.SaveAsync();
    }

    public void Add(PulseRecord entity)
    {
        this.context.PulseRecords.Add(entity);
        this.context.SaveChanges();
    }


    public Task UpdateAsync(int id, PulseRecord entity)
    {
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetAsync(id);
        DeleteAsync(entity);
    }

    public Task SaveAsync()
    {
        return context.SaveChangesAsync();
    }

    private void DeleteAsync(PulseRecord entity)
    {
        context.PulseRecords.Remove(entity);
    }
}