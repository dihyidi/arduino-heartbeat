using HeartBeatMonitoringApp.Models;

namespace HeartBeatMonitoringApp.Services;

public interface IUserService
{
    Task<bool> Login(LoginModel login);
    
    Task<UserModel> GetAsync(int id);

    Task AddAsync(UserModel model);

    Task UpdateAsync(int id, UserModel model);

    Task DeleteAsync(int id);
}