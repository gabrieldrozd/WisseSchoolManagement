using Microsoft.AspNetCore.Identity;
using Wisse.Modules.Users.Domain.Entities.Users;
using Wisse.Modules.Users.Domain.Interfaces.Services;

namespace Wisse.Modules.Users.Infrastructure.Services;

internal sealed class IdentityService : IIdentityService
{
    private readonly IPasswordHasher<User> _passwordHasher;

    public IdentityService(IPasswordHasher<User> passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }

    public string GenerateHashedPassword(User user)
    {
        var password = $"Wisse{Guid.NewGuid().ToString()[..4]}@";
        var passwordHash = _passwordHasher.HashPassword(user, password);
        return passwordHash;
    }
}