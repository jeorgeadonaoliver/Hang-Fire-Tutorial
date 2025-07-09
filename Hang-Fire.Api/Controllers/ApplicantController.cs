using FluentResults;
using Hang_Fire.Api.Common;
using Hang_Fire.Application.Features.Applicants.Command.CreateApplicant;
using Hang_Fire.Application.Features.Applicants.Command.UpdateApplicant;
using Hang_Fire.Application.Features.Applicants.Query.GetApplicant;
using Hang_Fire.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hang_Fire.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IRequestDispatcher _dispatcher;
        private readonly ILogger<ApplicantController> _logger;
        public ApplicantController(IRequestDispatcher dispatcher, ILogger<ApplicantController> logger)
        {
            _dispatcher = dispatcher;
            _logger = logger;
        }

        [HttpPost("CreateApplicant")]
        public async Task<IActionResult> CreateApplicant([FromBody] CreateApplicantCommand command, CancellationToken cancellationToken)
        {
            var result = await _dispatcher.Send(command, cancellationToken);
            return result.FilterResult(_logger) ?? Ok(result.Value);
        }

        [HttpGet("GetApplicant")]
        public async Task<IActionResult> GetApplicant(CancellationToken cancellationToken) 
        {
            var result = await _dispatcher.Send(new GetApplicantQuery(), cancellationToken);
            return result.FilterResult(_logger) ?? Ok(result.Value); 
        }

        [HttpPost("UpdateApplicant")]
        public async Task<IActionResult> UpdateApplicant([FromBody] UpdateApplicantCommand command, CancellationToken cancellationToken)
        {
            var result = await _dispatcher.Send(command, cancellationToken);
            return result.FilterResult(_logger) ?? Ok(result.Value);
        }
    }
}
