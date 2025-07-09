using Hang_Fire.Application.Interfaces.httpClient;
using Hang_Fire.Http.Cat;
using Hang_Fire.Http.Joke;
using Hang_Fire.Http.Kanye;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace Hang_Fire.Http;

public static class HttpClientServiceRegistration
{
    public static IServiceCollection AddHttpClientService(this IServiceCollection service) 
    {
     
        service.AddHttpClient<ICatClient, CatApiClient>();
        service.AddHttpClient<IJokeClient, JokeApiClient>();
        service.AddHttpClient<IKanyeClient, KanyeClient>()

            .AddPolicyHandler(PollyPolicyRegistry.GetRetryPolicy())
            .AddPolicyHandler(PollyPolicyRegistry.GetCircuitBreakerPolicy())
            .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(10)));

        return service;
    }
}
