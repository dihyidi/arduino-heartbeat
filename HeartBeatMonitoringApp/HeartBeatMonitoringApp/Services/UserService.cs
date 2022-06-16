using System.Linq.Expressions;
using HeartBeatMonitoringApp.Infrastructure.DataAccess.Repositories;
using HeartBeatMonitoringApp.Infrastructure.Database.Entities;
using HeartBeatMonitoringApp.Models;

namespace HeartBeatMonitoringApp.Services;

public class UserService : IUserService
{
    private readonly IUserRepository repository;

    public UserService(IUserRepository repository)
    {
        this.repository = repository;
    }

    public async Task<UserModel> GetAsync(int id)
    {
        var user = await repository.GetAsync(id);
        return ToModel(user);
    }

    public async Task AddAsync(UserModel model)
    {
        await repository.AddAsync(ToEntity(model));
    }

    public Task UpdateAsync(int id, UserModel model)
    {
        return repository.UpdateAsync(id, ToEntity(model));
    }

    public Task DeleteAsync(int id)
    {
        return repository.DeleteAsync(id);
    }

    public Task<bool> Login(LoginModel login)
    {
        Expression<Func<UserEntity, bool>> predicate = x => x.Email == login.Email && x.Password == login.Password;
        return repository.AnyAsync(predicate);
    }

    private static UserModel ToModel(UserEntity entity)
    {
        return new ()
        {
            Id = entity.Id,
            AvgSleepTime = entity.AvgSleepTime,
            ActivityLevel = entity.ActivityLevel,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            NormalPulse = entity.NormalPulse,
        };
    }

    private static UserEntity ToEntity(UserModel model)
    {
        return new ()
        {
            Id = model.Id,
            AvgSleepTime = model.AvgSleepTime,
            ActivityLevel = model.ActivityLevel,
            FirstName = model.FirstName,
            LastName = model.LastName,
            NormalPulse = model.NormalPulse,
        };
    }
}