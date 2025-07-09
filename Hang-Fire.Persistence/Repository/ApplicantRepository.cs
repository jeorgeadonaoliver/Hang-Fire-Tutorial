using Hang_Fire.Application.Interfaces;
using Hang_Fire.Domain.JobHunt;
using Hang_Fire.Persistence.Context;

namespace Hang_Fire.Persistence.Repository;

public class ApplicantRepository : Repository<Applicant>, IApplicantRepository
{
    public ApplicantRepository(JobHuntDbContext context) : base(context) { }
    
}
