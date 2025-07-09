using FluentResults;
using Hang_Fire.Application.Interfaces;


namespace Hang_Fire.Application.Features.Applicants.Query.GetApplicant
{
    public record GetApplicantQuery : IRequest<Result<IEnumerable<GetApplicantQueryDto>>>;

}
