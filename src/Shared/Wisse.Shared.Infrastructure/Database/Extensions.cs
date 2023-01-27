using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Wisse.Shared.Infrastructure.Database.Models;

namespace Wisse.Shared.Infrastructure.Database;

public static class Extensions
{
    private const string SectionName = "database";

    internal static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        var options = services.GetOptions<DatabaseOptions>(SectionName);
        services.AddSingleton(options);

        return services;
    }

    public static IServiceCollection AddDatabase<T>(this IServiceCollection services)
        where T: DbContext
    {
        var options = services.GetOptions<DatabaseOptions>(SectionName);
        services.AddDbContext<T>(x =>
        {
            x.UseNpgsql(options.ConnectionString);
        });

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        return services;
    }

    public static IServiceCollection AddDatabaseInitializer(this IServiceCollection services)
    {
        services.AddHostedService<DatabaseInitializer>();

        return services;
    }
}
