using HeartBeatMonitoringApp.Infrastructure.Database;
using HeartBeatMonitoringApp.Serial;
using HeartBeatMonitoringApp.Services;
using Microsoft.EntityFrameworkCore;

namespace HeartBeatMonitoringApp;

public static class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        host = CreateDbIfNotExists(host);
        host = RegisterEventHandlers(host);
        host.Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }

    private static void Initialize(DbContext context)
    {
        context.Database.Migrate();
    }

    private static IHost CreateDbIfNotExists(IHost host)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<HeartBeatMonitoringAppDbContext>();
        Initialize(context);
        return host;
    }

    private static IHost RegisterEventHandlers(IHost host)
    {
        using var scope = host.Services.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IPulseService>();
        var provider = scope.ServiceProvider.GetRequiredService<SerialPortProvider>();
        provider.DataReceived += service.OnGetPulseRecord;
        return host;
    }
}