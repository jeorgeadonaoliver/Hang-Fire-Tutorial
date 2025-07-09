using Hang_Fire.Application.Interfaces;
using Hang_Fire.Domain;
using Hangfire;
using Microsoft.Extensions.Logging;

namespace Hang_Fire.Application.Features.BackgroundJobs;

public class ServiceHandler : IServiceHandler
{
    private readonly IServiceFactory _factory;
    private readonly ILogger<ServiceHandler> _logger;

    public ServiceHandler(IServiceFactory factory, ILogger<ServiceHandler> logger)
    {
        _factory = factory;
        _logger = logger;
    }

    public Task<string> ExecuteService(ServiceType serviceType, string param)
    {
        try
        {
            var service = _factory.Execute(serviceType);

            string jobId= BackgroundJob.Enqueue(() => service.ExecuteService(param));
            _logger.LogInformation($"Background {serviceType} with parameter {param} has been enqueued.");
            return Task.FromResult(jobId);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to enqueue email job to {string.Join("; ", ex.Message)}!");
            return Task.FromResult(ex.Message);
        }
    }

}
