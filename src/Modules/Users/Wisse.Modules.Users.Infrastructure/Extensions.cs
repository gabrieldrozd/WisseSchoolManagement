using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Wisse.Modules.Users.Domain.Entities.Users.Base;
using Wisse.Modules.Users.Infrastructure.Database;
using Wisse.Shared.Infrastructure.Database;

[assembly: InternalsVisibleTo("Wisse.Modules.Users.Api")]

namespace Wisse.Modules.Users.Infrastructure;

internal static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDatabase<UsersDbContext>();

        var builder = services.AddIdentityCore<User>(options =>
        {
            options.User.RequireUniqueEmail = true;

            options.Password.RequiredLength = 8;
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = true;
        });

        builder = new IdentityBuilder(typeof(User), typeof(Role), builder.Services);
        builder.AddEntityFrameworkStores<UsersDbContext>().AddDefaultTokenProviders();
        builder.AddSignInManager<SignInManager<User>>();
        builder.AddUserManager<UserManager<User>>();

        services.AddSingleton<ISystemClock, SystemClock>();
        services.AddDataProtection();

        return services;
    }
}
