using Wisse.Modules.Users.Domain.Entities.Users;

namespace Wisse.Modules.Users.Domain.Interfaces.Services;

public interface IIdentityService
{
    string GenerateHashedPassword(User user);
}