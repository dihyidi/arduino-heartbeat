using HeartBeatMonitoringApp.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HeartBeatMonitoringApp.Infrastructure.DataAccess;

public class HeartBeatMonitoringAppDbContextFactory : IDesignTimeDbContextFactory<HeartBeatMonitoringAppDbContext>
{
    public HeartBeatMonitoringAppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<HeartBeatMonitoringAppDbContext>();
        optionsBuilder.UseSqlServer(
            "Data Source=localhost;Initial Catalog=HbMonitoringDb;Integrated Security=True;MultipleActiveResultSets=True");

        return new HeartBeatMonitoringAppDbContext(optionsBuilder.Options);
    }
}