using Hang_Fire.Application.Interfaces;
using Hang_Fire.Persistence.Context;
using Hang_Fire.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hang_Fire.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<JobHuntDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("JobHuntConnection")));

        services.AddScoped<IApplicantRepository, ApplicantRepository>();
        services.AddScoped<IRequestDispatcher, RequestDispatcher>();

        return services;
    }
}
