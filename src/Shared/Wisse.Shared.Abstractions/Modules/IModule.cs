using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Wisse.Shared.Abstractions.Modules;

public interface IModule
{
    string Name { get; }
    string Path { get; }
    IEnumerable<string> Permissions { get; }

    void RegisterModule(IServiceCollection services);

    void UseModule(WebApplication app);
}