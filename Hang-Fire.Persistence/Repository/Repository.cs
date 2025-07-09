using FluentResults;
using Hang_Fire.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Hang_Fire.Persistence.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result> AddAsync(T entity, CancellationToken cancellationToken)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            var rowsAffected = await _dbContext.SaveChangesAsync(cancellationToken);

            if(rowsAffected == 0)
                return Result.Fail("Insert failed. No rows affected.");

            return Result.Ok();
        }

        public async Task<Result<bool>> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
        {
            var isAny = await _dbContext.Set<T>().AsNoTracking().AnyAsync(expression, cancellationToken);
            return Result.Ok(isAny);
        }

        public async Task<Result<IEnumerable<T>>> GetAllAsync(CancellationToken cancellationToken)
        {
            var list = await _dbContext.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
            
            if(!list.Any())
                return Result.Fail("No records found.");

            return Result.Ok<IEnumerable<T>>(list);
        }


        public async Task<Result<T>> GetDetailAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
        {
            var data = await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(expression, cancellationToken);

            if(data is null)
                return Result.Fail("Record not found.");

            return Result.Ok(data);
        }

        public async Task<Result> UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            var rowsAffected = await _dbContext.SaveChangesAsync(cancellationToken);

            if(rowsAffected == 0)
                return Result.Fail("Update failed. No rows affected.");

            return Result.Ok();
        }
    }
}
