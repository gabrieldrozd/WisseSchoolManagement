using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Wisse.Shared.Abstractions.Modules;

namespace Wisse.Shared.Infrastructure.Modules.Information;

internal static class Extensions
{
    public static IServiceCollection AddModuleInformation(this IServiceCollection services, IEnumerable<IModule> modules)
    {
        var moduleInfoProvider = new ModuleInfoProvider();
        var moduleInfo = modules?.Select(x => new ModuleInfo(x.Name, x.Path, x.Permissions ?? Enumerable.Empty<string>())) ??
                         Enumerable.Empty<ModuleInfo>();

        moduleInfoProvider.Modules.AddRange(moduleInfo);
        services.AddSingleton(moduleInfoProvider);

        return services;
    }

    internal static void MapModuleInformation(this IEndpointRouteBuilder endpoint)
    {
        endpoint.MapGet("modules", async context =>
        {
            var moduleInfoProvider = context.RequestServices.GetRequiredService<ModuleInfoProvider>();
            await context.Response.WriteAsJsonAsync(moduleInfoProvider.Modules);
        });
    }
}