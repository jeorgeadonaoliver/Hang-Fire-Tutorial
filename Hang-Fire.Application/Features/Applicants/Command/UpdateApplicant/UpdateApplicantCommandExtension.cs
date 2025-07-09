using Hang_Fire.Domain.JobHunt;


namespace Hang_Fire.Application.Features.Applicants.Command.UpdateApplicant;

public static class UpdateApplicantCommandExtension
{
    public static Applicant mapToApplicant(this UpdateApplicantCommand command)
    {
        return new Applicant
        {            
            Id = command.Id,
            LastName = command.LastName,
            FirstName = command.FirstName,
            Email = command.Email,
            PositionApplying = command.PositionApplying
        };
    }
}
