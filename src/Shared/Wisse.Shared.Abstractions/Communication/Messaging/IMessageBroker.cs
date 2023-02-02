using Wisse.Common.Communication;

namespace Wisse.Shared.Abstractions.Communication.Messaging;

public interface IMessageBroker
{
    Task PublishAsync(params IMessage[] messages);
}