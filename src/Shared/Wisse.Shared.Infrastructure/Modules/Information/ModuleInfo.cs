namespace Wisse.Shared.Infrastructure.Modules.Information;

internal record ModuleInfo(string Name, string Path, IEnumerable<string> Permissions);