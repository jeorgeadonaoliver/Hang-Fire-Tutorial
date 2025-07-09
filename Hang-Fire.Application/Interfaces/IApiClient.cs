namespace Hang_Fire.Application.Interfaces;

public interface IApiClient
{
    Task<string> GetDataAsync();
}
