using HeartBeatMonitoringApp.Models;
using HeartBeatMonitoringApp.Serial;

namespace HeartBeatMonitoringApp.Services;

public interface IPulseService
{
    Task<List<PulseRecordModel>> GetAllAsync(int userId);

    void OnGetPulseRecord(object sender, PulseDataReceivedEventArgs e);

    void Start(int userId);
}