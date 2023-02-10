using Wisse.Common.Domain.Primitives;
using Wisse.Common.Domain.ValueObjects;
using Wisse.Modules.Users.Domain.Definitions;
using Wisse.Modules.Users.Domain.Entities.Users;

namespace Wisse.Modules.Users.Domain.Entities;

public class Student : AggregateRoot
{
    public Date BirthDate { get; private set; }
    public EducationDetails EducationDetails { get; private set; }
    public LanguageLevel LanguageLevel { get; private set; }

    public Contact Contact { get; set; }

    #region Foreign

    public virtual StudentUser User { get; set; }

    #endregion

    private Student(Guid externalId) : base(externalId)
    {
    }

    private Student(Guid externalId, Date birthDate, LanguageLevel languageLevel, EducationDetails educationDetails)
        : base(externalId)
    {
        BirthDate = birthDate;
        LanguageLevel = languageLevel;
        EducationDetails = educationDetails;
    }

    public static Student Create(Guid externalId, StudentDefinition definition)
    {
        var date = new Date(definition.BirthDate);
        var languageLevel = new LanguageLevel(definition.LevelKey);
        var education = new EducationDetails(definition.School, definition.Grade);

        return new Student(externalId, date, languageLevel, education);
    }

    public void SetContact(Contact contact)
        => Contact = contact;
}