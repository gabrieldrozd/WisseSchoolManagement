using Microsoft.AspNetCore.Identity;
using Wisse.Modules.Users.Domain.ValueObjects.User;

namespace Wisse.Modules.Users.Domain.Entities.Users.Base;

public abstract class User : IdentityUser<Guid>
{
    public override Guid Id { get; set; }
    public override string Email { get; set; }
    public override string UserName { get; set; }
    public override string PhoneNumber { get; set; }
    public FirstName FirstName { get; set; }
    public LastName LastName { get; set; }

    protected User()
    {
    }

    protected User(Guid userId, string email, string userName, string phoneNumber, string firstName, string lastName)
    {
        SetUserId(userId);
        SetEmail(email);
        SetUserName(userName);
        SetPhoneNumber(phoneNumber);

        FirstName = new FirstName(firstName);
        LastName = new LastName(lastName);
    }

    private void SetUserId(Guid userId)
        => Id = userId;

    private void SetEmail(string email)
        => Email = email;

    private void SetUserName(string userName)
        => UserName = userName;

    private void SetPhoneNumber(string phoneNumber)
        => PhoneNumber = phoneNumber;
}