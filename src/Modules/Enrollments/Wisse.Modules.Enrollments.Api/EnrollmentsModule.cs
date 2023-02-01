using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Wisse.Modules.Enrollments.Application;
using Wisse.Modules.Enrollments.Domain;
using Wisse.Modules.Enrollments.Infrastructure;
using Wisse.Shared.Abstractions.Modules;
using Wisse.Shared.Infrastructure.Api.Settings;

namespace Wisse.Modules.Enrollments.Api;

internal class EnrollmentsModule : IModule
{
    public const string BaseName = ApiSettings.EnrollmentsName;
    public const string BasePath = ApiGroups.Enrollments;

    public const string EnrollmentsArea = "Enrollments";

    public string Name => BaseName;
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