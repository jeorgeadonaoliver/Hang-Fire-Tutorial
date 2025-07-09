using Hang_Fire.Application.Interfaces;
using Hang_Fire.Application.Interfaces.backgroundService;
using Hang_Fire.Job.ApiClient;
using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hang_Fire.Service;

public static class JobRegistrationService
{
    public static IServiceCollection AddHangfireServices(this IServiceCollection services, IConfiguration configuration) 
    {
        services.AddHangfire(cfg => cfg.UseSqlServerStorage(configuration.GetConnectionString("HangfireConnection")));
        services.AddHangfireServer();

        services.AddTransient<EmailService>();
        services.AddTransient<NotificationService>();
        services.AddTransient<IServiceFactory, ServiceFactory>();
        services.AddTransient<IApiService, ProcessApiClient>();

        return services;
    }
}
