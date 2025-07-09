namespace Hang_Fire.Domain.JobHunt;

public partial class Applicant
{
    public Guid Id { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PositionApplying { get; set; } = null!;
}
