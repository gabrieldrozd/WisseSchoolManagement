using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Wisse.Shared.Infrastructure.Communication.External.Notices;

namespace Wisse.Shared.Infrastructure.Communication.External;

internal static class Extensions
{
    public static IServiceCollection AddExternalCommunication(this IServiceCollection services, IList<Assembly> assemblies)
    {
        services.AddNotices(assemblies);

        return services;
    }
}