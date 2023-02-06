using System.Reflection;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Wisse.Shared.Abstractions.Messaging;

namespace Wisse.Shared.Infrastructure.Messaging;

public static class Extensions
{
    private const string SectionName = "messaging";

    public static IServiceCollection AddMessaging(this IServiceCollection services, IList<Assembly> assemblies)
    {
        var options = services.GetOptions<MessagingOptions>(SectionName);

        services.AddMassTransit(x =>
        {
            x.SetKebabCaseEndpointNameFormatter();

            x.AddConsumers(ExtractModuleAssemblies(assemblies));

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(options.Host, options.VirtualHost, h =>
                {
                    h.Username(options.Username);
                    h.Password(options.Password);
                });

                cfg.ConfigureEndpoints(context);
            });
        });

        services.AddTransient<IMessageBus, MessageBus>();

        return services;
    }

    private static Assembly[] ExtractModuleAssemblies(IList<Assembly> assemblies)
    {
        const string modulePart = "Wisse.Modules";
        var enumerable = assemblies as Assembly[] ?? assemblies.ToArray();
        var moduleAssemblies = enumerable
            .Where(x => x.FullName is not null && x.FullName.Contains(modulePart))
            .ToArray();

        return moduleAssemblies;
    }
}