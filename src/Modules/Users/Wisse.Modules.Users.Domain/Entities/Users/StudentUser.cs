using Wisse.Modules.Users.Domain.Entities.Users.Base;

namespace Wisse.Modules.Users.Domain.Entities.Users;

public class StudentUser : User
{
    public int StudentId { get; }
    public virtual Student Student { get; set; }

    private StudentUser()
    {
    }

    private StudentUser(int studentId, Guid userId, string email, string userName, string phoneNumber, string firstName, string lastName)
        : base(userId, email, userName, phoneNumber, firstName, lastName)
    {
        StudentId = studentId;
    }

    public static StudentUser Create(
        int studentId, Guid userId, string email, string userName, string phoneNumber, string firstName, string lastName)
        => new(studentId, userId, email, userName, phoneNumber, firstName, lastName);
}