using Wisse.Modules.Users.Domain.Entities.Users.Base;

namespace Wisse.Modules.Users.Domain.Entities.Users;

public class AdminUser : User
{
    private AdminUser()
    {
    }

    private AdminUser(Guid userId, string email, string userName, string phoneNumber, string firstName, string lastName)
        : base(userId, email, userName, phoneNumber, firstName, lastName)
    {
    }

    public static AdminUser Create(Guid userId, string email, string userName, string phoneNumber, string firstName, string lastName)
        => new(userId, email, userName, phoneNumber, firstName, lastName);
}