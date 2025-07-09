using Hang_Fire.Application.Features.Applicants.Command.UpdateApplicant;
using Hang_Fire.Application.Features.Applicants.Query.GetApplicant;
using Hang_Fire.Domain.JobHunt;

namespace Hang_Fire.Application.Extension;

public static class ApplicantExtension
{
    public static GetApplicantQueryDto MapToGetApplicantQueryDto(this Applicant applicant) 
    {
        return new GetApplicantQueryDto
        {
            Id = applicant.Id,
            LastName = applicant.LastName,
            FirstName = applicant.FirstName,
            Email = applicant.Email,
            PositionApplying = applicant.PositionApplying
        };
    }

    public static UpdateApplicantCommand MapToUpdateApplicantCommand(this Applicant applicant) 
    {
        return new UpdateApplicantCommand
        {
            Id = applicant.Id,
            LastName = applicant.LastName,
            FirstName = applicant.FirstName,
            Email = applicant.Email,
            PositionApplying = applicant.PositionApplying
        };
    }
}
