using Wisse.Common.Domain.Primitives;
using Wisse.Common.Domain.ValueObjects;
using Wisse.Modules.Enrollments.Domain.Constants;
using Wisse.Modules.Enrollments.Domain.Definitions;
using Wisse.Modules.Enrollments.Domain.ValueObjects.Applicant;

namespace Wisse.Modules.Enrollments.Domain.Entities;

public class Applicant : Entity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Date BirthDate { get; private set; }

    public EducationDetails EducationDetails { get; private set; }
    public LanguageLevel LanguageLevel { get; private set; }

    public int EnrollmentId { get; set; }
    public Enrollment Enrollment { get; set; }

    private Applicant(Guid externalId) : base(externalId)
    {
    }

    private Applicant(
        Guid externalId, string firstName, string lastName, Date birthDate, EducationDetails educationDetails, LanguageLevel languageLevel)
        : this(externalId)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        EducationDetails = educationDetails;
        LanguageLevel = languageLevel;
    }

    public static Applicant Create(ApplicantDefinition definition)
    {
        var date = new Date(definition.BirthDate);
        var education = EducationDetails.Create(Education.FromName(definition.School), definition.Grade);
        var languageLevel = LanguageLevel.Create(Level.FromKey(definition.LevelKey));

        return new Applicant(definition.Id, definition.FirstName, definition.LastName, date, education, languageLevel);
    }
}