using HeartBeatMonitoringApp.Infrastructure.DataAccess;
using HeartBeatMonitoringApp.Infrastructure.DataAccess.Repositories;
using HeartBeatMonitoringApp.Infrastructure.Database;
using HeartBeatMonitoringApp.Serial;
using HeartBeatMonitoringApp.Services;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace HeartBeatMonitoringApp;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    private IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<HeartBeatMonitoringAppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("Database")));

        services.AddHttpClient();
        services.AddSwaggerGen();

        services.AddControllersWithViews().AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        });

        services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/build"; });

        services.AddSingleton<SerialPortProvider>();
        services.AddSingleton<HeartBeatMonitoringAppDbContextFactory>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPulseRepository, PulseRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPulseService, PulseService>();

        services.AddCors(options =>
        {
            options.AddPolicy("EnableAll",
                builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            c.RoutePrefix = "api/swagger";
        });

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseSpaStaticFiles();

        app.UseRouting();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        
        app.UseCors(builder => { 
            builder.AllowAnyOrigin();
            builder.AllowAnyHeader();
            builder.AllowAnyMethod(); 
        });

        app.UseSpa(spa =>
        {
            spa.Options.SourcePath = "ClientApp";

            if (env.IsDevelopment()) spa.UseReactDevelopmentServer("start");
        });
    }
}