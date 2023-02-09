using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Wisse.Modules.Users.Domain.Entities.Users;
using Wisse.Modules.Users.Domain.Interfaces.Repositories;
using Wisse.Modules.Users.Domain.Interfaces.Services;
using Wisse.Modules.Users.Domain.Interfaces.UnitOfWork;
using Wisse.Modules.Users.Infrastructure.Database;
using Wisse.Modules.Users.Infrastructure.Database.Repositories.Command;
using Wisse.Modules.Users.Infrastructure.Database.Repositories.Query;
using Wisse.Modules.Users.Infrastructure.Database.UnitOfWork;
using Wisse.Modules.Users.Infrastructure.Services;
using Wisse.Shared.Infrastructure.Database;

[assembly: InternalsVisibleTo("Wisse.Modules.Users.Api")]

namespace Wisse.Modules.Users.Infrastructure;

internal static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDatabase<UsersDbContext>();

        services.AddScoped<ICommandStudentRepository, CommandStudentRepository>();
        services.AddScoped<IQueryStudentRepository, QueryStudentRepository>();

        services.AddScoped<ICommandTeacherRepository, CommandTeacherRepository>();
        services.AddScoped<IQueryTeacherRepository, QueryTeacherRepository>();

        services.AddScoped<IQueryUserRepository, QueryUserRepository>();
        services.AddScoped<ICommandUserRepository, CommandUserRepository>();

        services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
        services.AddScoped<IIdentityService, IdentityService>();

        services.AddUnitOfWork<IUsersUnitOfWork, UsersUnitOfWork>();

        return services;
    }
}
