namespace Wisse.Shared.Infrastructure.Modules.Registry;

internal interface IModuleRegistry
{
    IEnumerable<ModuleBroadcastRegistration> GetBroadcastRegistrations(string key);

    void AddBroadcastAction(Type requestType, Func<object, Task> action);
}