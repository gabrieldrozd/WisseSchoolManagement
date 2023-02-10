using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Wisse.Shared.Abstractions.Caching;
using Wisse.Shared.Abstractions.Communication.Internal.Queries;

namespace Wisse.Shared.Infrastructure.Communication.Internal.Queries;

internal static class Extensions
{
    public static IServiceCollection AddQueries(this IServiceCollection services, IList<Assembly> assemblies)
    {
        services.AddSingleton<IQueryDispatcher, QueryDispatcher>();

        services.Scan(scan => scan.FromAssemblies(assemblies)
            .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}
