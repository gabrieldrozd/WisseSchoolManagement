using Wisse.Common.Communication;

namespace Wisse.Shared.Abstractions.Messaging;

public interface IMessageBus
{
    Task Publish<TMessage>(TMessage message, CancellationToken cancellationToken = default)
        where TMessage : class, IMessage;
}