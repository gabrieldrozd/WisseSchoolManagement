using Microsoft.Extensions.DependencyInjection;
using Wisse.Shared.Abstractions.Modules.Communication;

namespace Wisse.Shared.Infrastructure.Modules.Communication.Client;

internal static class Extensions
{
    public static IServiceCollection AddModuleClient(this IServiceCollection services)
    {
        services.AddSingleton<IModuleClient, ModuleClient>();

        return services;
    }
}
