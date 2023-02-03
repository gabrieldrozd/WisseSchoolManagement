using Wisse.Modules.Users.Domain.Entities.Users.Base;

namespace Wisse.Modules.Users.Domain.Entities.Users;

public class TeacherUser : User
{
    public Guid TeacherId { get; }
    public virtual Teacher Teacher { get; set; }

    private TeacherUser()
    {
    }

    private TeacherUser(Guid teacherId, Guid userId, string email, string userName, string phoneNumber, string firstName, string lastName)
        : base(userId, email, userName, phoneNumber, firstName, lastName)
    {
        TeacherId = teacherId;
    }

    public static TeacherUser Create(
        Guid studentId, Guid userId, string email, string userName, string phoneNumber, string firstName, string lastName)
        => new(studentId, userId, email, userName, phoneNumber, firstName, lastName);
}