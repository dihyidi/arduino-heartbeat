using System.Linq.Expressions;
using HeartBeatMonitoringApp.Infrastructure.Database;
using HeartBeatMonitoringApp.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HeartBeatMonitoringApp.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly HeartBeatMonitoringAppDbContext context;

    public UserRepository(HeartBeatMonitoringAppDbContext context)
    {
        this.context = context;
    }

    public Task<bool> AnyAsync(Expression<Func<UserEntity, bool>> predicate)
    {
        return context.Users.AnyAsync(predicate);
    }

    public Task<UserEntity> GetAsync(int id)
    {
        return context.Users.FirstAsync(x => x.Id == id);
    }

    public async Task AddAsync(UserEntity entity)
    {
        await context.Users.AddAsync(entity);
        await this.SaveAsync();
    }

    public Task UpdateAsync(int id, UserEntity entity)
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
    
    public void Add(UserEntity entity)
    {
        this.context.Users.Add(entity);
        this.context.SaveChanges();
    }
    
    private void DeleteAsync(UserEntity entity)
    {
        context.Users.Remove(entity);
    }
}