using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Wisse.Modules.Users.Application;
using Wisse.Modules.Users.Domain;
using Wisse.Modules.Users.Infrastructure;
using Wisse.Shared.Abstractions.Modules;
using Wisse.Shared.Infrastructure.Api.Settings;

namespace Wisse.Modules.Users.Api;

internal class UsersModule : IModule
{
    public const string BaseName = ApiSettings.UsersName;
    public const string BasePath = ApiGroups.Users;

    public string Name => BaseName;
    public string Path => BasePath;
    public IEnumerable<string> Policies { get; } = new[]
    {
        "users"
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

    public static class Areas
    {
        public const string Auth = "Auth";
        public const string Users = "Users";
        public const string Students = "Students";
        public const string Teachers = "Teachers";
    }
}