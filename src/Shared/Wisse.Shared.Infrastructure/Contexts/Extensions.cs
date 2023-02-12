using Microsoft.Extensions.DependencyInjection;
using Wisse.Shared.Abstractions.Contexts;

namespace Wisse.Shared.Infrastructure.Contexts;

internal static class Extensions
{
    public static IServiceCollection AddContexts(this IServiceCollection services)
    {
        services.AddSingleton<IUserContext, UserContext>();

        return services;
    }
}
