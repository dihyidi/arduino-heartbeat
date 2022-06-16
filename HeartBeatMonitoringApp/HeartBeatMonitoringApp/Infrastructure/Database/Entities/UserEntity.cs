using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HeartBeatMonitoringApp.Infrastructure.Database.Enums;

namespace HeartBeatMonitoringApp.Infrastructure.Database.Entities;

[Table("Users")]
public class UserEntity : IEntity
{
    [Required] public string FirstName { get; set; }

    [Required] public string LastName { get; set; }

    [Required] [EmailAddress] public string Email { get; set; }

    [Required] public string Password { get; set; }

    public DateTime RegistrationDate { get; set; }

    public int NormalPulse { get; set; }

    public int AvgSleepTime { get; set; }

    public ActivityLevel ActivityLevel { get; set; }
    public int Id { get; set; }
    
    public virtual List<PulseRecord> Pulse { get; set; }
}