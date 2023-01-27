using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Wisse.Modules.Enrollments.Application;
using Wisse.Modules.Enrollments.Domain;
using Wisse.Modules.Enrollments.Infrastructure;
using Wisse.Shared.Abstractions.Modules;

namespace Wisse.Modules.Enrollments.Api;

internal class EnrollmentsModule : IModule
{
    public const string BasePath = "enrollments-module";

    public string Name { get; } = "Enrollments";
    public string Path => BasePath;
    public IEnumerable<string> Policies { get; } = new[]
    {
        "enrollments"
    };

    public void RegisterModule(IServiceCollection services)
    {
        services
            .AddInfrastructure()
            .AddApplication()
            .AddDomain();
    }

    public void UseModule(WebApplication app)
    {
    }
}