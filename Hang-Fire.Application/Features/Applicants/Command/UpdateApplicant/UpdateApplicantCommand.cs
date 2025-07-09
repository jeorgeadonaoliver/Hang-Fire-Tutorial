using FluentResults;
using Hang_Fire.Application.Interfaces;

namespace Hang_Fire.Application.Features.Applicants.Command.UpdateApplicant
{
    public class UpdateApplicantCommand : IRequest<Result<Guid>>
    {
        public Guid Id { get; set; } 

        public string LastName { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PositionApplying { get; set; } = null!;
    }
}
