using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Wisse.Shared.Abstractions.Communication.External.Notices;

namespace Wisse.Shared.Infrastructure.Communication.External.Notices;

internal static class Extensions
{
    public static IServiceCollection AddNotices(this IServiceCollection services, IEnumerable<Assembly> assemblies)
    {
        services.AddSingleton<INoticeDispatcher, NoticeDispatcher>();

        services.Scan(s => s.FromAssemblies(assemblies)
            .AddClasses(c => c.AssignableTo(typeof(INoticeHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}
