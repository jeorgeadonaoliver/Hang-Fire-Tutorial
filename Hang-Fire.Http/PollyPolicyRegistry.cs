using Polly;
using Polly.Extensions.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hang_Fire.Http;

public static class PollyPolicyRegistry
{
    public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(
                retryCount: 3,
                sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), // exponential backoff
                onRetry: (outcome, timespan, retryAttempt, context) =>
                {
                    Console.WriteLine($"Retry {retryAttempt} after {timespan.TotalSeconds} seconds.");
                });
    }

    public static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .CircuitBreakerAsync(
                handledEventsAllowedBeforeBreaking: 3,
                durationOfBreak: TimeSpan.FromSeconds(30),
                onBreak: (outcome, breakDelay) =>
                {
                    Console.WriteLine($"Circuit broken! Delay: {breakDelay.TotalSeconds}s");
                },
                onReset: () => Console.WriteLine("Circuit closed."),
                onHalfOpen: () => Console.WriteLine("Circuit is half-open. Testing connection...")
            );
    }

}
