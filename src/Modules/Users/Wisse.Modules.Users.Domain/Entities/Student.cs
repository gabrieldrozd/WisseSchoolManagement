using System.ComponentModel.DataAnnotations.Schema;
using Wisse.Common.Domain.Primitives;
using Wisse.Common.Domain.ValueObjects;
using Wisse.Modules.Users.Domain.Entities.Users;
using Wisse.Modules.Users.Domain.ValueObjects.Student;

namespace Wisse.Modules.Users.Domain.Entities;

public class Student : AggregateRoot
{
    public Date BirthDate { get; private set; }
    public EducationDetails EducationDetails { get; private set; }
    public LanguageLevel LanguageLevel { get; private set; }

    public Contact Contact { get; set; }

    #region Foreign

    [ForeignKey("Id")]
    public Guid UserId { get; set; }
    public virtual StudentUser AppUser { get; set; }

    #endregion

    private Student(Guid externalId) : base(externalId)
    {
    }
}