using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Wisse.Shared.Infrastructure.Messaging.Mediator.Commands;
using Wisse.Shared.Infrastructure.Messaging.Mediator.Queries;

namespace Wisse.Shared.Infrastructure.Messaging.Mediator;

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
