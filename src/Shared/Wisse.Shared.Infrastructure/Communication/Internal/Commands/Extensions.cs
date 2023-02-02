using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Wisse.Shared.Abstractions.Communication.Internal.Commands;

namespace Wisse.Shared.Infrastructure.Communication.Internal.Commands;

internal static class Extensions
{
    public static IServiceCollection AddCommands(this IServiceCollection services, IList<Assembly> assemblies)
    {
        services.AddSingleton<ICommandDispatcher, CommandDispatcher>();

        services.Scan(scan => scan.FromAssemblies(assemblies)
            .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}