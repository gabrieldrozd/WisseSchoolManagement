namespace Wisse.Shared.Infrastructure.Modules.Models;

internal record ModuleInfoProvider
{
    public List<ModuleInfo> Modules { get; } = new();
}