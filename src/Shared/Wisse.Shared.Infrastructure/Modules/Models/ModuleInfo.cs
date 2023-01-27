namespace Wisse.Shared.Infrastructure.Modules.Models;

internal record ModuleInfo(string Name, string Path, IEnumerable<string> Policies);