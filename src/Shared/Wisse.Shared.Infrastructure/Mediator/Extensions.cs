using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Wisse.Shared.Infrastructure.Mediator.Commands;
using Wisse.Shared.Infrastructure.Mediator.Queries;

namespace Wisse.Shared.Infrastructure.Mediator;

internal static class Extensions
{
    public static IServiceCollection AddMediator(this IServiceCollection services, IList<Assembly> assemblies)
    {
        services
            .AddCommands(assemblies)
            .AddQueries(assemblies);

        return services;
    }
}
