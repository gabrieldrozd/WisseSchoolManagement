using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Wisse.Shared.Infrastructure.Communication.External;

internal static class Extensions
{
    public static IServiceCollection AddExternalCommunication(this IServiceCollection services, IList<Assembly> assemblies)
    {
        return services;
    }
}