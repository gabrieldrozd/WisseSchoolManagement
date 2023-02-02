using Microsoft.Extensions.DependencyInjection;

namespace Wisse.Shared.Infrastructure.Modules.Communication.Serializer;

internal static class Extensions
{
    public static IServiceCollection AddModuleSerializer(this IServiceCollection services)
    {
        services.AddSingleton<IModuleSerializer, ModuleSerializer>();

        return services;
    }
}
