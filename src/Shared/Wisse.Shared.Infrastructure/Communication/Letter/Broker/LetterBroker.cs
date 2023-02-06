using Wisse.Common.Communication;
using Wisse.Shared.Abstractions.Communication.Messaging;
using Wisse.Shared.Infrastructure.Communication.Letter.Dispatcher;

namespace Wisse.Shared.Infrastructure.Communication.Letter.Broker;

internal sealed class LetterBroker : ILetterBroker
{
    private readonly ILetterDispatcher _letterDispatcher;

    public LetterBroker(ILetterDispatcher letterDispatcher)
    {
        _letterDispatcher = letterDispatcher;
    }

    public async Task PublishAsync(params ILetter[] messages)
    {
        if (messages is null)
            return;

        messages = messages.Where(x => x is not null).ToArray();

        if (!messages.Any())
            return;

        foreach (var message in messages)
            await _letterDispatcher.PublishAsync(message);
    }
}