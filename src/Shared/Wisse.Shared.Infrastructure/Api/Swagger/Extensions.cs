using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Wisse.Shared.Infrastructure.Api.Swagger;

internal static class Extensions
{
    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(swagger =>
        {
            swagger.CustomSchemaIds(x => x.FullName);
            swagger.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Wisse API",
                Version = "v1",
            });
        });

        return services;
    }

    public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(setup =>
        {
            setup.RoutePrefix = "docs";
            setup.DocumentTitle = "Wisse API";
            setup.SwaggerEndpoint("/swagger/v1/swagger.json", "Wisse API");
        });

        return app;
    }
}
