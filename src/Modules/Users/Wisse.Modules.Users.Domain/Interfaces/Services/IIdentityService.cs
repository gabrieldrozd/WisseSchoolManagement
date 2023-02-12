using Wisse.Base.Results;
using Wisse.Modules.Users.Domain.Entities.Users;
using Wisse.Shared.Abstractions.Auth;

namespace Wisse.Modules.Users.Domain.Interfaces.Services;

public interface IIdentityService
{
    void GenerateHashedPassword(User user);

    Result<AccessToken> Login(User user, string password);
}