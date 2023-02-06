using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wisse.Shared.Abstractions.Modules;
using Wisse.Shared.Infrastructure.Api;
using Wisse.Shared.Infrastructure.Communication;
using Wisse.Shared.Infrastructure.Database;
using Wisse.Shared.Infrastructure.Messaging;
using Wisse.Shared.Infrastructure.Modules;

[assembly: InternalsVisibleTo("Wisse.Bootstrapper")]

namespace Wisse.Shared.Infrastructure;

internal static class Extensions
{
    private const string CorsPolicy = "cors";

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IList<Assembly> assemblies, IList<IModule> modules)
    {
        var disabledModules = new List<string>();
        using (var serviceProvider = services.BuildServiceProvider())
        {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            foreach (var (key, value) in configuration.AsEnumerable())
            {
                if (!key.Contains(":module:enabled"))
                    continue;

                if (!bool.Parse(value!))
                    disabledModules.Add(key.Split(":")[0]);
            }
        }

        // TODO: Add CORS
        // services.AddCors(cors =>
        // {
        //     cors.AddPolicy(CorsPolicy, builder =>
        //     {
        //         builder
        //             .WithOrigins("*")
        //             .WithMethods("POST", "PUT", "DELETE")
        //             .WithHeaders("Content-Type", "Authorization");
        //     });
        // });

        services.AddSwaggerDocumentation();
        services.AddModulesConfiguration(assemblies, modules);
        services.AddCommunication(assemblies);
        services.AddMessaging(assemblies);

        services.AddDatabaseAndInitializer();
        services.AddControllersConfiguration(disabledModules);

        return services;
    }

    public static IApplicationBuilder UseInfrastructure(this WebApplication app)
    {
        app.UseSwaggerDocumentation();
        app.UseRouting();

        return app;
    }

    public static string GetModuleName(this object value)
        => value?.GetType().GetModuleName() ?? string.Empty;

    public static T GetOptions<T>(this IServiceCollection services, string sectionName) where T : new()
    {
        using var serviceProvider = services.BuildServiceProvider();
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();
        return configuration.BindOptions<T>(sectionName);
    }

    private static string GetModuleName(this Type type)
    {
        const string modulePart = "Wisse.Modules.";
        if (type?.Namespace is null)
        {
            return string.Empty;
        }

        var moduleName = type.Namespace.StartsWith(modulePart)
            ? type.Namespace.Split(".")[2].ToLowerInvariant()
            : string.Empty;

        return moduleName;
    }

    private static T BindOptions<T>(this IConfiguration configuration, string sectionName) where T : new()
    {
        var options = new T();
        configuration.GetSection(sectionName).Bind(options);
        return options;
    }
}