namespace Wisse.Shared.Infrastructure.Modules.Information;

internal record ModuleInfoProvider
{
    public List<ModuleInfo> Modules { get; } = new();
}