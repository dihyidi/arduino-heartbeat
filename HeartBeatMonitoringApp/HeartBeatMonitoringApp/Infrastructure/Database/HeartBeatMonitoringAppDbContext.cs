using HeartBeatMonitoringApp.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace HeartBeatMonitoringApp.Infrastructure.Database;

public class HeartBeatMonitoringAppDbContext : DbContext
{
    public HeartBeatMonitoringAppDbContext(DbContextOptions<HeartBeatMonitoringAppDbContext> options)
        : base(options)
    {
    }

    public DbSet<UserEntity> Users { get; set; }

    public DbSet<PulseRecord> PulseRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>(entity =>
        {
            entity.HasIndex(e => e.Email).IsUnique();

            entity.HasIndex(e => new { e.Email, e.Password });
        });
        
        modelBuilder.Entity<PulseRecord>(entity =>
        {
            entity.HasOne(e => e.UserEntity)
                .WithMany(x => x.Pulse)
                .HasForeignKey(e => e.UserId);
        });
    }
}