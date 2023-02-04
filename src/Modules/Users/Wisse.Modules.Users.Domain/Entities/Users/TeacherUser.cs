using Wisse.Modules.Users.Domain.Entities.Users.Base;

namespace Wisse.Modules.Users.Domain.Entities.Users;

public class TeacherUser : User
{
    public int TeacherId { get; }
    public virtual Teacher Teacher { get; set; }

    private TeacherUser()
    {
    }

    private TeacherUser(int teacherId, Guid userId, string email, string userName, string phoneNumber, string firstName, string lastName)
        : base(userId, email, userName, phoneNumber, firstName, lastName)
    {
        TeacherId = teacherId;
    }

    public static TeacherUser Create(
        int teacherId, Guid userId, string email, string userName, string phoneNumber, string firstName, string lastName)
        => new(teacherId, userId, email, userName, phoneNumber, firstName, lastName);
}