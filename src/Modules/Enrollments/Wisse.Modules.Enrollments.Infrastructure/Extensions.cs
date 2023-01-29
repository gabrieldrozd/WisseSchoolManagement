using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using Wisse.Modules.Enrollments.Domain.Repositories;
using Wisse.Modules.Enrollments.Infrastructure.Database;
using Wisse.Modules.Enrollments.Infrastructure.Database.Repositories;
using Wisse.Shared.Infrastructure.Database;

[assembly: InternalsVisibleTo("Wisse.Modules.Enrollments.Api")]

namespace Wisse.Modules.Enrollments.Infrastructure;

internal static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDatabase<EnrollmentsDbContext>();

        services.AddScoped<ICommandEnrollmentRepository, CommandEnrollmentRepository>();
        services.AddScoped<IQueryEnrollmentRepository, QueryEnrollmentRepository>();

        return services;
    }
}
