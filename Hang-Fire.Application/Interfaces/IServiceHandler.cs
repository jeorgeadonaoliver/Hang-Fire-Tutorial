using Hang_Fire.Domain;

namespace Hang_Fire.Application.Interfaces
{
    public interface IServiceHandler
    {
        Task<string> ExecuteService(ServiceType serviceType, string param);
    }
}
