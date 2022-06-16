namespace HeartBeatMonitoringApp.Serial;

public sealed class PulseDataReceivedEventArgs : EventArgs
{
    public PulseDataReceivedEventArgs(int count)
    {
        PulseCount = count;
    }

    public int PulseCount { get; }
}