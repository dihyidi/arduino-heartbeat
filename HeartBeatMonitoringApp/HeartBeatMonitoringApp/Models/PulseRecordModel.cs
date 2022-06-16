using HeartBeatMonitoringApp.Infrastructure.Database.Enums;

namespace HeartBeatMonitoringApp.Models;

public record PulseRecordModel(int Count, DateTime Date, TriggerType TriggerType) : IModel
{
    public int Id { get; set; }
}