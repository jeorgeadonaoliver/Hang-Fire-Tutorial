using FluentResults;
using Hang_Fire.Application.Features.Applicants.Command.CreateApplicant;
using Hang_Fire.Application.Features.Applicants.Query.GetApplicant;
using Hang_Fire.Application.Features.BackgroundJobs;
using Hang_Fire.Application.Interfaces;
using Hang_Fire.Application.Interfaces.backgroundService;
using Microsoft.Extensions.DependencyInjection;

namespace Hang_Fire.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IServiceHandler, ServiceHandler>();

        services.AddScoped<IRequestHandler<GetApplicantQuery, Result<IEnumerable<GetApplicantQueryDto>>>, GetApplicantQueryHandler>();
        services.AddScoped<IRequestHandler<CreateApplicantCommand, Result<Guid>>, CreateApplicantCommandHandler>();
        return services;
    }
}
