using FluentValidation;
using Hang_Fire.Application.Interfaces;

namespace Hang_Fire.Application.Features.Applicants.Command.UpdateApplicant
{
    public class UpdateApplicantCommandValidation : AbstractValidator<UpdateApplicantCommand>
    {
        private readonly IApplicantRepository _repository;

        public UpdateApplicantCommandValidation(IApplicantRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.")
                .MustAsync(IsApplicantIdExist).WithMessage("Applicant with this Id does not exist.");
        }

        private async Task<bool> IsApplicantIdExist(Guid id, CancellationToken cancellationToken)
        {
            var result = await _repository.AnyAsync(x => x.Id == id, cancellationToken);
            return result.Value;
        }
    }
}
