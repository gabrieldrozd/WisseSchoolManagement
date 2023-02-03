using Wisse.Modules.Users.Domain.Entities.Users.Base;

namespace Wisse.Modules.Users.Domain.Entities.Users;

public class StudentUser : User
{
    public Guid StudentId { get; }
    public virtual Student Student { get; set; }

    private StudentUser()
    {
    }

    private StudentUser(Guid studentId, Guid userId, string email, string userName, string phoneNumber, string firstName, string lastName)
        : base(userId, email, userName, phoneNumber, firstName, lastName)
    {
        StudentId = studentId;
    }

    public static StudentUser Create(
        Guid studentId, Guid userId, string email, string userName, string phoneNumber, string firstName, string lastName)
        => new(studentId, userId, email, userName, phoneNumber, firstName, lastName);
}