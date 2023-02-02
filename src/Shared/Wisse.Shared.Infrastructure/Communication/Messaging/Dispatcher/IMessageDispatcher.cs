using Wisse.Common.Communication;

namespace Wisse.Shared.Infrastructure.Communication.Messaging.Dispatcher;

internal interface IMessageDispatcher
{
    Task PublishAsync<TMessage>(TMessage message)
        where TMessage : class, IMessage;
}