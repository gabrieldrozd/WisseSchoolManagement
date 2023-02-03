using System.ComponentModel.DataAnnotations.Schema;
using Wisse.Common.Domain.Primitives;
using Wisse.Modules.Users.Domain.Entities.Users;

namespace Wisse.Modules.Users.Domain.Entities;

public class Teacher : Entity // TODO: Test if AggregateRoot works here
{
    // TODO: Add properties for Teacher.

    #region Foreign

    [ForeignKey("Id")]
    public Guid UserId { get; set; }
    public virtual TeacherUser AppUser { get; set; }

    #endregion

    private Teacher(Guid externalId) : base(externalId)
    {
    }
}