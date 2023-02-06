using MassTransit;
using Wisse.Common.Communication;

namespace Wisse.Shared.Abstractions.Messaging;

public interface IMessageBus
{
    Task PublishMessage<TMessage>(TMessage message, CancellationToken cancellationToken = default)
        where TMessage : class, IMessage;

    Task<Response<TResponse>> PublishRequest<TMessage, TResponse>(TMessage message, CancellationToken cancellationToken = default)
        where TMessage : class, IMessage
        where TResponse : class;
}