using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Wisse.Shared.Infrastructure.Communication.External;
using Wisse.Shared.Infrastructure.Communication.Internal;
using Wisse.Shared.Infrastructure.Communication.Letter;

namespace Wisse.Shared.Infrastructure.Communication;

internal static class Extensions
{
    public static IServiceCollection AddCommunication(this IServiceCollection services, IList<Assembly> assemblies)
    {
        // Adds messaging: MessageBroker, MessageDispatcher, MessageBackgroundServices
        services.AddLetters();

        // Adds external communication: EventHandler, EventDispatcher
        services.AddExternalCommunication(assemblies);

        // Adds internal communication: CommandHandler, CommandDispatcher, QueryHandler, QueryDispatcher
        services.AddInternalCommunication(assemblies);

        return services;
    }
}