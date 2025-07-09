namespace Hang_Fire.Application.Features.Applicants.Query.GetApplicant;

public class GetApplicantQueryDto
{
    public Guid Id { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? Email { get; set; }

    public string? PositionApplying { get; set; }
}
