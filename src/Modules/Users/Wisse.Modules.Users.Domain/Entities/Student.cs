using System.ComponentModel.DataAnnotations.Schema;
using Wisse.Common.Domain.Primitives;
using Wisse.Common.Domain.ValueObjects;
using Wisse.Modules.Users.Domain.Definitions;
using Wisse.Modules.Users.Domain.Entities.Users;
using Wisse.Modules.Users.Domain.ValueObjects.User;

namespace Wisse.Modules.Users.Domain.Entities;

public class Student : AggregateRoot
{
    public Date BirthDate { get; private set; }
    public EducationDetails EducationDetails { get; private set; }
    public Permission Permission { get; private set; }

    public Contact Contact { get; set; }

    #region Foreign

    [ForeignKey("Id")]
    public Guid UserId { get; set; }
    public virtual StudentUser User { get; set; }

    #endregion

    private Student(Guid externalId) : base(externalId)
    {
    }

    private Student(Guid externalId, Guid userId, Date birthDate, Permission permission, EducationDetails educationDetails)
        : base(externalId)
    {
        UserId = userId;
        BirthDate = birthDate;
        Permission = permission;
        EducationDetails = educationDetails;
    }

    public static Student Create(Guid externalId, Guid userId, StudentDefinition definition)
    {
        var date = new Date(definition.BirthDate);
        var languageLevel = new Permission(definition.LevelKey);
        var education = new EducationDetails(definition.School, definition.Grade);

        return new Student(externalId, userId, date, languageLevel, education);
    }

    public void SetContact(Contact contact)
        => Contact = contact;
}