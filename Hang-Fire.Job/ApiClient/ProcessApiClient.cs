using Hang_Fire.Application.Interfaces;
using Hang_Fire.Application.Interfaces.backgroundService;
using Hangfire;

namespace Hang_Fire.Job.ApiClient
{
    public class ProcessApiClient : IApiService
    {
        public async Task GetDataAsync(IApiClient apiClient)
        {
            await Task.Delay(1000);
            var id = BackgroundJob.Enqueue(() => apiClient.GetDataAsync());
        }
    }
}
