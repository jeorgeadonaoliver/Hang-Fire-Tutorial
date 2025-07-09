using Hang_Fire.Application.Interfaces;
using Hang_Fire.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Hang_Fire.Service;

public class ServiceFactory : IServiceFactory
{
    private readonly IServiceProvider _serviceProvider;
    public ServiceFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IService Execute(ServiceType serviceType)
    {
        return serviceType switch
        {
            ServiceType.Email => _serviceProvider.GetRequiredService<EmailService>(),
            ServiceType.Notification => _serviceProvider.GetRequiredService<NotificationService>(),
            _ => throw new ArgumentOutOfRangeException(nameof(serviceType), serviceType, null)
        };
    }
}
