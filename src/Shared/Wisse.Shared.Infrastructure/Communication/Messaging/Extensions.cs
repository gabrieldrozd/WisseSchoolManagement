using Microsoft.Extensions.DependencyInjection;
using Wisse.Shared.Abstractions.Communication.Messaging;
using Wisse.Shared.Infrastructure.Communication.Messaging.Broker;
using Wisse.Shared.Infrastructure.Communication.Messaging.Channels;
using Wisse.Shared.Infrastructure.Communication.Messaging.Dispatcher;

namespace Wisse.Shared.Infrastructure.Communication.Messaging;

internal static class Extensions
{
    public static IServiceCollection AddMessaging(this IServiceCollection services)
    {
        services.AddSingleton<IMessageBroker, MessageBroker>();
        services.AddSingleton<IMessageDispatcher, MessageDispatcher>();
        services.AddSingleton<IMessageChannel, MessageChannel>();

        services.AddHostedService<BackgroundDispatcher>();

        return services;
    }
}
