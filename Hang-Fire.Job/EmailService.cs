using Hang_Fire.Application.Interfaces;
using Microsoft.Extensions.Logging;


namespace Hang_Fire.Job
{
    public class EmailService : IService
    {
        private readonly ILogger<EmailService> _logger;
        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger;
        }

        public async Task ExecuteService(string param)
        {
            try {
                await Task.Delay(10000);
                Console.WriteLine($"[Background] Sent an Confirmation Email to {param} ");
                _logger.LogInformation($"[Background] Sent an Confirmation Email to {param} ");
                return;
            } 
            catch (Exception ex) 
            {
                Console.WriteLine($"[Background] Error on Confirmation Email");
                _logger.LogError($"[Background] Error on Confirmation Email: {ex.Message}");
                return;
            }

        }

    }
}
