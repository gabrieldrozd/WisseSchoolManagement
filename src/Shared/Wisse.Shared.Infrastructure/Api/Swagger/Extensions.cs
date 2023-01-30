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
            swagger.CustomSchemaIds(x => x.Name);
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
        app.UseSwaggerUI(options =>
        {
            options.RoutePrefix = "docs";
            options.DocumentTitle = "Wisse API";
            options.DefaultModelExpandDepth(-1);
            options.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Model);
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Wisse API");
        });

        return app;
    }
}