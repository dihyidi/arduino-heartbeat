using System.IO.Ports;

namespace HeartBeatMonitoringApp.Serial;

public class SerialPortProvider
{
    public delegate void PulseRecordHandler(object sender, PulseDataReceivedEventArgs args);

    public SerialPortProvider()
    {
        var ports = SerialPort.GetPortNames().OrderBy(
                a => a.Length > 3 &&
                     int.TryParse(a.AsSpan(3), out var num)
                    ? num
                    : 0)
            .ToArray();

        Serial = new SerialPort(ports[0]);
        if (Serial.IsOpen) return;

        Serial.Open();
        Serial.DataReceived += OnGetDataFromSerial;
    }

    public SerialPort Serial { get; }

    public event PulseRecordHandler? DataReceived;

    private void OnGetDataFromSerial(object sender, SerialDataReceivedEventArgs args)
    {
        var data = Serial.ReadChar();
        DataReceived?.Invoke(this, new PulseDataReceivedEventArgs(data));
    }
}