using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Wisse.Shared.Abstractions.Communication.External.Events;

namespace Wisse.Shared.Infrastructure.Communication.External.Events;

internal static class Extensions
{
    public static IServiceCollection AddEvents(this IServiceCollection services, IEnumerable<Assembly> assemblies)
    {
        services.AddSingleton<IEventDispatcher, EventDispatcher>();

        services.Scan(s => s.FromAssemblies(assemblies)
            .AddClasses(c => c.AssignableTo(typeof(IEventHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}
