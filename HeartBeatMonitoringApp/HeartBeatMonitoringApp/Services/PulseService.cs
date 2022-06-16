using HeartBeatMonitoringApp.Infrastructure.DataAccess.Repositories;
using HeartBeatMonitoringApp.Infrastructure.Database.Entities;
using HeartBeatMonitoringApp.Models;
using HeartBeatMonitoringApp.Serial;

namespace HeartBeatMonitoringApp.Services;

public class PulseService : IPulseService
{
    private readonly IPulseRepository repository;
    private readonly SerialPortProvider provider;

    public PulseService(IPulseRepository repository, SerialPortProvider provider)
    {
        this.repository = repository;
        this.provider = provider;
    }

    public async Task<List<PulseRecordModel>> GetAllAsync(int userId)
    {
        var models = await repository.GetAllAsync(userId);
        return models.Select(ToModel).ToList();
    }

    public void OnGetPulseRecord(object sender, PulseDataReceivedEventArgs e)
    {
        this.repository.Add(CreatePulseRecord(e.PulseCount));
    }

    public void Start(int userId)
    {
        provider.Serial.Write("1");
    }

    private static PulseRecordModel ToModel(PulseRecord entity)
    {
        return new(entity.Value, entity.DateTime, entity.Type)
        {
            Id = entity.Id
        };
    }

    private static PulseRecord ToEntity(PulseRecordModel model)
    {
        return new(model.Count)
        {
            DateTime = DateTime.Now,
            UserId = 1
        };
    }
    
    private static PulseRecord CreatePulseRecord(int count)
    {
        return new(count)
        {
            DateTime = DateTime.Now,
            UserId = 1
        };
    }

}