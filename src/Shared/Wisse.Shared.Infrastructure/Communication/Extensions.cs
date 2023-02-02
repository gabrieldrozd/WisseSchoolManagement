using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Wisse.Shared.Infrastructure.Communication.External;
using Wisse.Shared.Infrastructure.Communication.Internal;

namespace Wisse.Shared.Infrastructure.Communication;

internal static class Extensions
{
    public static IServiceCollection AddCommunication(this IServiceCollection services, IList<Assembly> assemblies)
    {
        services.AddExternalCommunication(assemblies);
        services.AddInternalCommunication(assemblies);

        return services;
    }
}