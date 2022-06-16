using System.ComponentModel.DataAnnotations.Schema;
using HeartBeatMonitoringApp.Infrastructure.Database.Enums;

namespace HeartBeatMonitoringApp.Infrastructure.Database.Entities;

[Table("PulseRecords")]
public record PulseRecord(int Value) : IEntity
{
    public DateTime DateTime { get; set; }

    public TriggerType Type { get; set; }

    public int UserId { get; set; }

    public virtual UserEntity UserEntity { get; set; }
    
    public int Id { get; set; }
}