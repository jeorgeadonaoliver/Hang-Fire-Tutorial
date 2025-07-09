using FluentResults;
using FluentValidation;
using Hang_Fire.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace Hang_Fire.Application.Features.Applicants.Command.CreateApplicant
{
    public class CreateApplicantCommandValidation : AbstractValidator<CreateApplicantCommand>
    {
        private readonly IApplicantRepository _repository;
        public CreateApplicantCommandValidation(IApplicantRepository repository )
        {
            _repository = repository;

            RuleFor(x => x.FirstName)
                .NotNull().WithMessage("First name is required!");

            RuleFor(x => x.LastName)
                .NotNull().WithMessage("Last name is required!");

            RuleFor(x => x.Email)
                .NotNull().WithMessage("Email is required!")
                .EmailAddress().WithMessage("Invalid email format!")
                .MustAsync(IsEmailUnique).WithMessage("Try using different Email!");

            RuleFor(x => x.PositionApplying)
                .NotNull().WithMessage("Position applying is required!");
        }

        private async Task<bool> IsEmailUnique(string email, CancellationToken cancellationToken)
        {
            var result = await _repository.AnyAsync(x => x.Email == email, cancellationToken);
            return !result.Value;

        }
    }
}
