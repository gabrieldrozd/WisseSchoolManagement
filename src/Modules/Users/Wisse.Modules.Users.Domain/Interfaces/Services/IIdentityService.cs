using Wisse.Base.Results;
using Wisse.Modules.Users.Domain.Entities.Users;

namespace Wisse.Modules.Users.Domain.Interfaces.Services;

public interface IIdentityService
{
    void GenerateHashedPassword(User user);

    Result Login(User user, string password);
}