using FluentResults;
using Hang_Fire.Application.Common;
using Hang_Fire.Application.Interfaces;
using Hang_Fire.Domain;

namespace Hang_Fire.Application.Features.Applicants.Command.UpdateApplicant
{
    public class UpdateApplicantCommandHandler : IRequestHandler<UpdateApplicantCommand, Result<Guid>>
    {
        private readonly IApplicantRepository _repository;
        private readonly IServiceHandler _service;
        public UpdateApplicantCommandHandler(IApplicantRepository repository, IServiceHandler service)
        {
            _repository = repository;
            _service = service;
        }
        public async Task<Result<Guid>> Handle(UpdateApplicantCommand request, CancellationToken cancellationToken)
        {
            var validationHandler = await FluentValidationHandler.ValidateAsync<UpdateApplicantCommand>(
                new UpdateApplicantCommandValidation(_repository), request, cancellationToken);

            if (validationHandler.IsFailed) 
            {
                var errors = validationHandler.Errors.Select(e => e.Message).ToList();
                return Result.Fail(errors);
            }

            var result = await _repository.UpdateAsync(request.mapToApplicant(), cancellationToken);
            if (result.IsFailed)
            {
                return Result.Fail(result.Errors);
            }

            var email_id = await _service.ExecuteService(ServiceType.Email, request.Email);
            var notification_id = await _service.ExecuteService(ServiceType.Notification, email_id);

            return Result.Ok(request.Id);
        }
    }
}
