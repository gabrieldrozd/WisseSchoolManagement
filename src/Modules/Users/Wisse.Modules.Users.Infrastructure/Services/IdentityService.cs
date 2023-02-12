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
    private readonly ITokenProvider _tokenProvider;

    public IdentityService(
        IPasswordHasher<User> passwordHasher,
        ITokenProvider tokenProvider)
    {
        _passwordHasher = passwordHasher;
        _tokenProvider = tokenProvider;
    }

    public void GenerateHashedPassword(User user)
    {
        var password = $"Wisse{Guid.NewGuid().ToString()[..4]}@";
        user.SetPasswordHash(_passwordHasher.HashPassword(user, password));
    }

    public Result<AccessToken> Login(User user, string password)
    {
        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
        if (result == PasswordVerificationResult.Failed)
        {
            return Result.Failure<AccessToken>(Failure.InvalidCredentials);
        }

        var accessToken = _tokenProvider.CreateToken(
            user.ExternalId,
            user.Email,
            user.Role,
            user.Permissions);

        return Result.Success(accessToken);
    }
}