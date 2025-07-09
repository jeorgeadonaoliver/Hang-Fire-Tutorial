using FluentResults;

namespace Hang_Fire.Application.Interfaces;

public interface IRequestDispatcher
{
    Task<Result<TResponse>> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
}
