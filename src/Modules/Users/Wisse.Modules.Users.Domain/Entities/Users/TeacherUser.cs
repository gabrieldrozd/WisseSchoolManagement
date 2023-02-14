using Wisse.Common.Auth;
using Wisse.Modules.Users.Domain.Definitions;

namespace Wisse.Modules.Users.Domain.Entities.Users;

public class TeacherUser : User
{
    public Guid TeacherExternalId { get; }
    public virtual Teacher Teacher { get; set; }

    private TeacherUser() : base(Guid.NewGuid())
    {
    }

    private TeacherUser(Guid userId, UserDefinition definition)
        : base(userId, UserRole.Teacher, definition, UserPermission.TeacherPermissions)
    {
    }

    public static TeacherUser Create(Guid userId, UserDefinition definition)
        => new(userId, definition);

    public void SetTeacher(Teacher teacher)
        => Teacher = teacher;
}