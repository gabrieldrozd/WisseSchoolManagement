using Microsoft.Extensions.DependencyInjection;
using Wisse.Shared.Infrastructure.Modules.Communication.Client;
using Wisse.Shared.Infrastructure.Modules.Communication.Serializer;

namespace Wisse.Shared.Infrastructure.Modules.Communication;

internal static class Extensions
{
    public static IServiceCollection AddModuleCommunication(this IServiceCollection services)
    {
        services.AddModuleClient();
        services.AddModuleSerializer();

        return services;
    }
}
