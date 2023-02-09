using Wisse.Modules.Users.Domain.Definitions;

namespace Wisse.Modules.Users.Domain.Entities.Users;

public class AdminUser : User
{
    private AdminUser() : base(Guid.NewGuid())
    {
    }

    private AdminUser(Guid userId, UserDefinition definition)
        : base(userId, Common.Auth.UserRole.Admin, definition)
    {
    }

    public static AdminUser Create(Guid userId, UserDefinition definition)
        => new(userId, definition);
}