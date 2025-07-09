using Hang_Fire.Application.Interfaces;
using Hang_Fire.Application.Interfaces.backgroundService;
using Hang_Fire.Application.Interfaces.httpClient;
using Microsoft.AspNetCore.Mvc;

namespace Hang_Fire.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpClientController : ControllerBase
    {
        private readonly ICatClient _catClient;
        private readonly IJokeClient _jokeClient;
        private readonly IKanyeClient _kanyeClient;
        private readonly IApiService _apiService;

        public HttpClientController(ICatClient catClient, IJokeClient jokeClient, IKanyeClient kanyeClient, IApiService apiService)
        {
            _catClient = catClient;
            _jokeClient = jokeClient;
            _kanyeClient = kanyeClient;
            _apiService = apiService;
        }


        [HttpGet("GetCat")]
        public async Task<IActionResult> GetCat()
        {
            //var result = await _catClient.GetDataAsync();
            await _apiService.GetDataAsync(_catClient);
            return Ok("cat api success");
        }

        [HttpGet("GetJoke")]
        public async Task<IActionResult> GetJoke()
        {
            await _apiService.GetDataAsync(_jokeClient);
            return Ok("joke api success");
        }


        [HttpGet("GetKanye")]
        public async Task<IActionResult> GetKanye()
        {
            await _apiService.GetDataAsync(_kanyeClient);
            return Ok("kanye api success");
        }
    }
}
