using Wisse.Common.Auth;
using Wisse.Modules.Users.Domain.Definitions;

namespace Wisse.Modules.Users.Domain.Entities.Users;

public class StudentUser : User
{
    public Guid StudentExternalId { get; private set; }
    public virtual Student Student { get; set; }

    private StudentUser() : base(Guid.NewGuid())
    {
    }

    private StudentUser(Guid externalId, Guid studentExternalId, UserDefinition definition)
        : base(externalId, UserRole.Student, definition, UserPermission.StudentPermissions)
    {
        StudentExternalId = studentExternalId;
    }

    public static StudentUser Create(Guid externalId, Guid studentExternalId, UserDefinition definition)
        => new(externalId, studentExternalId, definition);
}