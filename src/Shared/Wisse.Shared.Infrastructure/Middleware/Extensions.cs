using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Wisse.Shared.Infrastructure.Middleware;

internal static class Extensions
{
    public static IServiceCollection AddMiddlewareRegistration(this IServiceCollection services)
    {
        services.AddScoped<HttpRequestMiddleware>();

        return services;
    }

    public static IApplicationBuilder UseRegisteredMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<HttpRequestMiddleware>();

        return app;
    }
}
