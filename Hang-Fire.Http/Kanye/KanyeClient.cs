using Hang_Fire.Application.Interfaces.httpClient;

namespace Hang_Fire.Http.Kanye;

public class KanyeClient : IKanyeClient
{
    private readonly HttpClient _httpClient;

    public KanyeClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetDataAsync()
    {
        await Task.Delay(10000);
        var response = await _httpClient.GetAsync("https://api.kanye.rest");
        response.EnsureSuccessStatusCode();

        var data = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Kanye Api client Service Rendered: {data}");
        return data;
    }
}
