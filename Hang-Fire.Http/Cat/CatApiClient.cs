using Hang_Fire.Application.Interfaces;
using Hang_Fire.Application.Interfaces.httpClient;

namespace Hang_Fire.Http.Cat;

public class CatApiClient : ICatClient
{
    private HttpClient _httpClient;

    public CatApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetDataAsync()
    {
        var response = await _httpClient.GetAsync("https://catfact.ninja/fact");
        response.EnsureSuccessStatusCode();

        var data = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Cat Api client Service Rendered: {data}");
        return data;
    }
}
