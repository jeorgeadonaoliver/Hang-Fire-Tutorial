using FluentResults;
using Hang_Fire.Application.Extension;
using Hang_Fire.Application.Interfaces;
using Microsoft.Extensions.Logging;


namespace Hang_Fire.Application.Features.Applicants.Query.GetApplicant
{
    public class GetApplicantQueryHandler : IRequestHandler<GetApplicantQuery, Result<IEnumerable<GetApplicantQueryDto>>>
    {
        private readonly IApplicantRepository _repository;
        private ILogger<GetApplicantQueryHandler> _logger;
        public GetApplicantQueryHandler(IApplicantRepository repository, ILogger<GetApplicantQueryHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Result<IEnumerable<GetApplicantQueryDto>>> Handle(GetApplicantQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync(cancellationToken);
            if (result.IsFailed) 
            {
                return Result.Fail(result.Errors);
            }

            return Result.Ok(result.Value.Select(x => x.MapToGetApplicantQueryDto()));
        }
    }
}
