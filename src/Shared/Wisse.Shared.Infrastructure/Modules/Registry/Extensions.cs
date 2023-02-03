using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Wisse.Common.Communication.External;
using Wisse.Shared.Abstractions.Communication.External.Events;

namespace Wisse.Shared.Infrastructure.Modules.Registry;

internal static class Extensions
{
    public static IServiceCollection AddModuleRegistrations(this IServiceCollection services, IEnumerable<Assembly> assemblies)
    {
        var registry = new ModuleRegistry();

        var types = assemblies.SelectMany(x => x.GetTypes()).ToArray();
        var eventTypes = types.Where(x => x.IsClass && typeof(IEvent).IsAssignableFrom(x)).ToArray();

        services.AddSingleton<IModuleRegistry>(sp =>
        {
            var eventDispatcher = sp.GetRequiredService<IEventDispatcher>();
            var eventDispatcherType = eventDispatcher.GetType();

            foreach (var type in eventTypes)
            {
                registry.AddBroadcastAction(type, notice =>
                    (Task) eventDispatcherType.GetMethod(nameof(eventDispatcher.PublishAsync))
                        ?.MakeGenericMethod(type)
                        .Invoke(eventDispatcher, new[] { notice }));
            }

            return registry;
        });

        return services;
    }
}