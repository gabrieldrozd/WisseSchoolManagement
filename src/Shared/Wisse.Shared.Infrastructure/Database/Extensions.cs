using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Wisse.Shared.Abstractions.Database.UnitOfWork;
using Wisse.Shared.Infrastructure.Database.Models;
using Wisse.Shared.Infrastructure.Database.UnitOfWork;

namespace Wisse.Shared.Infrastructure.Database;

public static class Extensions
{
    private const string SectionName = "database";

    internal static IServiceCollection AddDatabaseAndInitializer(this IServiceCollection services)
    {
        var options = services.GetOptions<DatabaseOptions>(SectionName);
        services.AddSingleton(options);
        services.AddSingleton(new UnitOfWorkTypeRegistry());

        services.AddHostedService<DatabaseInitializer>();

        return services;
    }

    public static IServiceCollection AddDatabase<T>(this IServiceCollection services)
        where T : DbContext
    {
        var options = services.GetOptions<DatabaseOptions>(SectionName);
        services.AddDbContext<T>(x => { x.UseNpgsql(options.ConnectionString); });

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        return services;
    }

    public static IServiceCollection AddUnitOfWork<TUnitOfWork, TImplementation>(this IServiceCollection services)
        where TUnitOfWork : class, IUnitOfWork
        where TImplementation : class, TUnitOfWork
    {
        services.AddScoped<TUnitOfWork, TImplementation>();
        services.AddScoped<IUnitOfWork, TImplementation>();

        using var serviceProvider = services.BuildServiceProvider();
        serviceProvider.GetRequiredService<UnitOfWorkTypeRegistry>()
            .Register<TUnitOfWork>();

        return services;
    }
}