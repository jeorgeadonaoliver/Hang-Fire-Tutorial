using FluentResults;
using Hang_Fire.Application.Common;
using Hang_Fire.Application.Features.BackgroundJobs;
using Hang_Fire.Application.Interfaces;
using Hang_Fire.Application.Interfaces.backgroundService;
using Hang_Fire.Domain;
using Microsoft.Extensions.Logging;

namespace Hang_Fire.Application.Features.Applicants.Command.CreateApplicant;

public class CreateApplicantCommandHandler : IRequestHandler<CreateApplicantCommand, Result<Guid>>
{
    private readonly IApplicantRepository _applicantRepository;
    private readonly ILogger<CreateApplicantCommand> _logger;
    private readonly IServiceHandler _service;
    public CreateApplicantCommandHandler(IApplicantRepository applicantRepository, ILogger<CreateApplicantCommand> logger, IServiceHandler service)
    {
        _applicantRepository = applicantRepository;
        _logger = logger;
        _service = service;
    }

    public async Task<Result<Guid>> Handle(CreateApplicantCommand request, CancellationToken cancellationToken)
    {
        var validationHandler = await FluentValidationHandler.ValidateAsync<CreateApplicantCommand>(
            new CreateApplicantCommandValidation(_applicantRepository), request, cancellationToken);

        if (validationHandler.IsFailed)
        {
            var errors = validationHandler.Errors.Select(e => e.Message).ToList();
            return Result.Fail(errors);
        }

        var result = await _applicantRepository.AddAsync(request.mapToApplicant(), cancellationToken);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }

        var email_id = await _service.ExecuteService(ServiceType.Email, request.Email);
        var notification_id = await _service.ExecuteService(ServiceType.Notification, email_id);

        return Result.Ok(request.Id);
    }
}
