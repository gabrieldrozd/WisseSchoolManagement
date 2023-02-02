namespace Wisse.Shared.Abstractions.Modules.Communication;

public interface IModuleClient
{
    Task PublishAsync(object message);
}