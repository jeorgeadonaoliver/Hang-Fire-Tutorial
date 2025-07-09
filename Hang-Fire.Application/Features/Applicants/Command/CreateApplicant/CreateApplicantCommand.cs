using FluentResults;
using Hang_Fire.Application.Interfaces;


namespace Hang_Fire.Application.Features.Applicants.Command.CreateApplicant
{
    public class CreateApplicantCommand : IRequest<Result<Guid>>
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string LastName { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PositionApplying { get; set; } = null!;
    }
}
