using FluentResults;
using FluentValidation;
using FluentValidation.Results;

namespace Hang_Fire.Application.Common
{
    public class FluentValidationHandler
    {
        public static async Task<Result> ValidateAsync<T>(IValidator<T> validator, T commandInstance, CancellationToken cancellationToken = default)
        {
            if (commandInstance == null)
                return Result.Fail($"{typeof(T)} must not be null!");

            ValidationResult result = await validator.ValidateAsync(commandInstance, cancellationToken);
            if (result.IsValid)
                return Result.Ok();

            var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail(errors);
        }
    }
}
