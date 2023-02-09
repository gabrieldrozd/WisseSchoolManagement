using Wisse.Modules.Users.Domain.Definitions;
using Wisse.Modules.Users.Domain.Entities.Users.Base;

namespace Wisse.Modules.Users.Domain.Entities.Users;

public class AdminUser : User
{
    private AdminUser() : base(Guid.NewGuid())
    {
    }

    private AdminUser(Guid userId, string passwordHash, UserDefinition definition)
        : base(userId, passwordHash, Common.Auth.UserRole.Admin, definition)
    {
    }

    public static AdminUser Create(Guid userId, string passwordHash, UserDefinition definition)
        => new(userId, passwordHash, definition);
}