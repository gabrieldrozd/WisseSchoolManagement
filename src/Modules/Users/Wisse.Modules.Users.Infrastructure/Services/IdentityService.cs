using Microsoft.AspNetCore.Identity;
using Wisse.Base.Results;
using Wisse.Base.Results.Core;
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

    public void GenerateHashedPassword(User user)
    {
        var password = $"Wisse{Guid.NewGuid().ToString()[..4]}@";
        user.SetPasswordHash(_passwordHasher.HashPassword(user, password));
    }

    public Result Login(User user, string password)
    {
        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
        if (result == PasswordVerificationResult.Failed)
        {
            return Result.Failure(Failure.InvalidPassword);
        }

        // TODO: Token generation in here
        // For now we just return a success

        return Result.Success();
    }
}