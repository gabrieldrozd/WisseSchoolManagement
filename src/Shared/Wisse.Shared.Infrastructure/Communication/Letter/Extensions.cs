using Microsoft.Extensions.DependencyInjection;
using Wisse.Shared.Abstractions.Communication.Messaging;
using Wisse.Shared.Infrastructure.Communication.Letter.Broker;
using Wisse.Shared.Infrastructure.Communication.Letter.Channels;
using Wisse.Shared.Infrastructure.Communication.Letter.Dispatcher;

namespace Wisse.Shared.Infrastructure.Communication.Letter;

internal static class Extensions
{
    public static IServiceCollection AddLetters(this IServiceCollection services)
    {
        services.AddSingleton<ILetterBroker, LetterBroker>();
        services.AddSingleton<ILetterDispatcher, LetterDispatcher>();
        services.AddSingleton<ILetterChannel, LetterChannel>();

        services.AddHostedService<BackgroundDispatcher>();

        return services;
    }
}
