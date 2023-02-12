using Microsoft.Extensions.DependencyInjection;
using Wisse.Shared.Abstractions.Utilities;

namespace Wisse.Shared.Infrastructure.Utilities;

internal static class Extensions
{
    public static IServiceCollection AddUtilities(this IServiceCollection services)
    {
        services.AddSingleton<IClock, Clock>();

        return services;
    }
}
