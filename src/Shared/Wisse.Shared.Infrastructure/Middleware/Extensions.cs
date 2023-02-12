using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Wisse.Shared.Abstractions.Exceptions;
using Wisse.Shared.Infrastructure.Middleware.Exceptions;
using Wisse.Shared.Infrastructure.Middleware.Http;

namespace Wisse.Shared.Infrastructure.Middleware;

internal static class Extensions
{
    public static IServiceCollection AddMiddlewareRegistration(this IServiceCollection services)
    {
        services.AddScoped<HttpRequestMiddleware>();
        services.AddScoped<ExceptionMiddleware>();

        services.AddSingleton<IExceptionMapper, ExceptionMapper>();

        return services;
    }

    public static IApplicationBuilder UseRegisteredMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<HttpRequestMiddleware>();
        app.UseMiddleware<ExceptionMiddleware>();

        return app;
    }
}
