namespace Hang_Fire.Application.Features.Applicants.Command.UpdateApplicant
{
    public class UpdateApplicantCommand
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string LastName { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PositionApplying { get; set; } = null!;
    }
}
