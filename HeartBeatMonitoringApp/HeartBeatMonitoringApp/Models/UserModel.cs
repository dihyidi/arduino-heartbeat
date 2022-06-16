using HeartBeatMonitoringApp.Infrastructure.Database.Enums;

namespace HeartBeatMonitoringApp.Models;

public class UserModel : IModel
{
    public int Id { get; set; }
    
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int NormalPulse { get; set; }

    public int AvgSleepTime { get; set; }

    public ActivityLevel ActivityLevel { get; set; }
    
}