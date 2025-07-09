using Hang_Fire.Application.Interfaces;
using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hang_Fire.Job;

public static class JobRegistrationService
{
    public static IServiceCollection AddHangfireServices(this IServiceCollection services, IConfiguration configuration) 
    {
        services.AddHangfire(cfg => cfg.UseSqlServerStorage(configuration.GetConnectionString("HangfireConnection")));
        services.AddHangfireServer();

        services.AddTransient<EmailService>();
        services.AddTransient<NotificationService>();
        services.AddTransient<IServiceFactory, ServiceFactory>();

        return services;
    }
}
