using Hang_Fire.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace Hang_Fire.Service;

public class NotificationService : IService
{
    private readonly ILogger<NotificationService> _logger;
    public NotificationService(ILogger<NotificationService> logger)
    {
        _logger = logger;
    }

    public async Task ExecuteService(string param)
    {
        try
        {
            await Task.Delay(10000);
            Console.WriteLine($"[Background] Sent an Notification Email to {param} ");
            _logger.LogInformation($"[Background] Sent an Notification Email to {param}");
            return;
        }
        catch (Exception ex)
        {
            _logger.LogError($"[Background] Failed to send Notification Email: {ex.Message}");
            return;
        }
    }
}
