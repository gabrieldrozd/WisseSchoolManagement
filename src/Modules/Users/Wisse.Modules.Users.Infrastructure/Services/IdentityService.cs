using Microsoft.AspNetCore.Identity;
using Wisse.Base.Results;
using Wisse.Base.Results.Core;
using Wisse.Modules.Users.Domain.Entities.Users;
using Wisse.Modules.Users.Domain.Interfaces.Services;
using Wisse.Shared.Abstractions.Auth;

namespace Wisse.Modules.Users.Infrastructure.Services;

internal sealed class IdentityService : IIdentityService
{
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IAuthManager _authManager;

    public IdentityService(
        IPasswordHasher<User> passwordHasher,
        IAuthManager authManager)
    {
        _passwordHasher = passwordHasher;
        _authManager = authManager;
    }

    public void GenerateHashedPassword(User user)
    {
        var password = $"Wisse{Guid.NewGuid().ToString()[..4]}@";
        user.SetPasswordHash(_passwordHasher.HashPassword(user, password));
    }

    public Result<AuthResult> Login(User user, string password)
    {
        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
        if (result == PasswordVerificationResult.Failed)
        {
            return Result.Failure<AuthResult>(Failure.InvalidCredentials);
        }

        var token = _authManager.CreateToken(user.ExternalId, user.Email, user.Role, user.Permissions);
        var authResult = new AuthResult
        {
            UserId = user.ExternalId,
            Email = user.Email.Value,
            FullName = $"{user.FirstName.Value} {user.LastName.Value}",
            Role = user.Role.Value,
            Token = token,
            Permissions = user.Permissions.Select(x => x.Key).ToArray()
        };

        return Result.Success(authResult);
    }
}