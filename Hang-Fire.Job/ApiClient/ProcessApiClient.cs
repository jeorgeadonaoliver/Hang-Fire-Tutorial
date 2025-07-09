using Hang_Fire.Application.Interfaces;
using Hang_Fire.Application.Interfaces.backgroundService;
using Hangfire;

namespace Hang_Fire.Job.ApiClient
{
    public class ProcessApiClient : IProcessApiClient
    {
        public Task GetDataAsync(IApiClient apiClient)
        {
            var id = BackgroundJob.Enqueue(() => apiClient.GetDataAsync());
            return Task.CompletedTask;
        }
    }
}
