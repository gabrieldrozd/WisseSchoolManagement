using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wisse.Shared.Abstractions.Modules;
using Wisse.Shared.Infrastructure.Modules.Communication;
using Wisse.Shared.Infrastructure.Modules.Information;
using Wisse.Shared.Infrastructure.Modules.Registry;

namespace Wisse.Shared.Infrastructure.Modules;

internal static class Extensions
{
    internal static IServiceCollection AddModulesConfiguration(
        this IServiceCollection services,
        IEnumerable<Assembly> assemblies,
        IEnumerable<IModule> modules)
    {
        services.AddModuleInformation(modules);
        services.AddModuleRegistrations(assemblies);

        services.AddModuleCommunication();

        return services;
    }

    public static IHostBuilder ConfigureModules(this IHostBuilder builder)
    {
        return builder.ConfigureAppConfiguration((ctx, cfg) =>
        {
            foreach (var settings in GetSettings("*"))
            {
                cfg.AddJsonFile(settings);
            }

            foreach (var settings in GetSettings($"*.{ctx.HostingEnvironment.EnvironmentName}"))
            {
                cfg.AddJsonFile(settings);
            }

            IEnumerable<string> GetSettings(string pattern) => Directory.EnumerateFiles(
                ctx.HostingEnvironment.ContentRootPath, $"module.{pattern}.json", SearchOption.AllDirectories);
        });
    }
}