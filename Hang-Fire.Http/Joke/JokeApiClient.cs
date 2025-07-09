using Hang_Fire.Application.Interfaces.httpClient;


namespace Hang_Fire.Http.Joke
{
    public class JokeApiClient : IJokeClient
    {
        private HttpClient _httpClient;

        public JokeApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetDataAsync()
        {
            var response = await _httpClient.GetAsync("https://v2.jokeapi.dev/joke/Any");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Joke Api client Service Rendered: {data}");
            return data;
        }
    }
}
