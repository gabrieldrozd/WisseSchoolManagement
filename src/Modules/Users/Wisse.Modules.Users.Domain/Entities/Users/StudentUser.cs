using Wisse.Modules.Users.Domain.Definitions.Users;
using Wisse.Modules.Users.Domain.Entities.Users.Base;

namespace Wisse.Modules.Users.Domain.Entities.Users;

public class StudentUser : User
{
    public int StudentId { get; }
    public virtual Student Student { get; set; }

    private StudentUser()
    {
    }

    private StudentUser(Guid userId, string email, string userName, string phoneNumber, string firstName, string lastName)
        : base(userId, email, userName, phoneNumber, firstName, lastName)
    {
    }

    public static StudentUser Create(
        Guid userId, string email, string userName, string phoneNumber, string firstName, string lastName)
        => new(userId, email, userName, phoneNumber, firstName, lastName);

    public static StudentUser Create(Guid userId, StudentUserDefinition definition)
        => new(userId, definition.Email, definition.UserName, definition.PhoneNumber, definition.FirstName, definition.LastName);

    public void SetStudent(Student student)
        => Student = student;
}