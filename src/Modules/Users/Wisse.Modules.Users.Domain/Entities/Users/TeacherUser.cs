using Wisse.Modules.Users.Domain.Definitions;
using Wisse.Modules.Users.Domain.Entities.Users.Base;

namespace Wisse.Modules.Users.Domain.Entities.Users;

public class TeacherUser : User
{
    public Guid TeacherExternalId { get; }
    public virtual Teacher Teacher { get; set; }

    private TeacherUser() : base(Guid.NewGuid())
    {
    }

    private TeacherUser(Guid userId, string passwordHash, UserDefinition definition)
        : base(userId, passwordHash, Common.Auth.UserRole.Teacher, definition)
    {
    }

    public static TeacherUser Create(Guid userId, string passwordHash, UserDefinition definition)
        => new(userId, passwordHash, definition);

    public void SetTeacher(Teacher teacher)
        => Teacher = teacher;
}