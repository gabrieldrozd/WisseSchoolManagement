using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Wisse.Shared.Infrastructure.Api.Settings;

namespace Wisse.Shared.Infrastructure.Api.Swagger;

internal static class Extensions
{
    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(swagger =>
        {
            foreach (var group in ApiGroups.GetNameValueDictionary())
            {
                swagger.SwaggerDoc(
                    group.Value,
                    new OpenApiInfo
                    {
                        Title = $"{group.Key}",
                        Version = group.Value
                    });
            }
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

            foreach (var group in ApiGroups.GetNameValueDictionary())
            {
                options.SwaggerEndpoint($"/swagger/{group.Value}/swagger.json", $"{group.Key} API");
            }
        });

        return app;
    }
}