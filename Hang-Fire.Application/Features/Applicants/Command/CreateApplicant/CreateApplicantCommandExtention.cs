using Hang_Fire.Domain.JobHunt;

namespace Hang_Fire.Application.Features.Applicants.Command.CreateApplicant
{
    public static class CreateApplicantCommandExtention
    {
        public static Applicant mapToApplicant(this CreateApplicantCommand command)
        {
            return new Applicant
            {
                Id = Guid.NewGuid(),
                LastName = command.LastName,
                FirstName = command.FirstName,
                Email = command.Email,
                PositionApplying = command.PositionApplying
            };
        }
    }
}
