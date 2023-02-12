using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Wisse.Shared.Abstractions.Contexts;

namespace Wisse.Shared.Infrastructure.Contexts;

internal static class Extensions
{
    public static IServiceCollection AddContexts(this IServiceCollection services)
    {
        services.AddSingleton<IContextFactory, ContextFactory>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddTransient(sp => sp.GetRequiredService<IContextFactory>().Create());

        return services;
    }
}
