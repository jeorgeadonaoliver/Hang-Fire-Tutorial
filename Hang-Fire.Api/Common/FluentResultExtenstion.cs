using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Hang_Fire.Api.Common
{
    public static class FluentResultExtenstion
    {
        public static IActionResult FilterResult<T>(this Result<Result<T>> result, ILogger logger) 
        {
            if (result.IsFailed || result.Value.IsFailed)
            {
                var errors = result.Errors.Count == 0 ? result.Value.Errors : result.Errors;
                string errorMessage = string.Join("; ", errors.Select(e => e.Message));
                logger.LogError($"Throw BadRequest Exception: {errorMessage}");
                return new BadRequestObjectResult(errorMessage);
            }

            logger.LogInformation($"HttpRequest connection successfully.");

            return null!;
        }
    }
}
