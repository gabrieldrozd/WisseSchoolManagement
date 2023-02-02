using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Wisse.Shared.Infrastructure.Communication.Internal.Commands;
using Wisse.Shared.Infrastructure.Communication.Internal.Queries;

namespace Wisse.Shared.Infrastructure.Communication.Internal;

internal static class Extensions
{
    public static IServiceCollection AddInternalCommunication(this IServiceCollection services, IList<Assembly> assemblies)
    {
        services.AddCommands(assemblies);
        services.AddQueries(assemblies);

        return services;
    }
}