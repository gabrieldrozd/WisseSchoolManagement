using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using Wisse.Modules.Enrollments.Infrastructure.Database;
using Wisse.Shared.Infrastructure.Database;

[assembly: InternalsVisibleTo("Wisse.Modules.Enrollments.Api")]

namespace Wisse.Modules.Enrollments.Infrastructure;

internal static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDatabase<EnrollmentsDbContext>();

        return services;
    }
}
