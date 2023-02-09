using Wisse.Modules.Users.Domain.Definitions;
using Wisse.Modules.Users.Domain.Entities.Users.Base;

namespace Wisse.Modules.Users.Domain.Entities.Users;

public class StudentUser : User
{
    public Guid StudentExternalId { get; }
    public virtual Student Student { get; set; }

    private StudentUser() : base(Guid.NewGuid())
    {
    }

    private StudentUser(Guid userId, string passwordHash, UserDefinition definition)
        : base(userId, passwordHash, Common.Auth.UserRole.Student, definition)
    {
    }

    public static StudentUser Create(Guid userId, string passwordHash, UserDefinition definition)
        => new(userId, passwordHash, definition);

    public void SetStudent(Student student)
        => Student = student;
}