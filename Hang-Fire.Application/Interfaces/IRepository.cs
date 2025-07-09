using FluentResults;
using System.Linq.Expressions;

namespace Hang_Fire.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<Result<IEnumerable<T>>> GetAllAsync(CancellationToken cancellationToken);

        Task<Result<T>> GetDetailAsync(Expression<Func<T,bool>> expression, CancellationToken cancellationToken);

        Task<Result<bool>> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);

        Task<Result> AddAsync(T entity, CancellationToken cancellationToken);

        Task<Result> UpdateAsync(T entity, CancellationToken cancellationToken);
    }
}
