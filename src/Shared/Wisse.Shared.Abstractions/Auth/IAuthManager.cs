using Wisse.Common.Domain.ValueObjects;

namespace Wisse.Shared.Abstractions.Auth;

public interface IAuthManager
{
    string CreateToken(Guid userId, Email email, Role role, List<Permission> permissions);
}