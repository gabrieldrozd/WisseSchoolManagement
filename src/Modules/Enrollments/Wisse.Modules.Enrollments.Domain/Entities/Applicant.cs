using Wisse.Common.Domain.Primitives;
using Wisse.Common.Domain.ValueObjects;
using Wisse.Modules.Enrollments.Domain.Constants;
using Wisse.Modules.Enrollments.Domain.ValueObjects.Applicant;

namespace Wisse.Modules.Enrollments.Domain.Entities;

public class Applicant : Entity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Date BirthDate { get; private set; }

    public EducationDetails EducationDetails { get; private set; }
    public LanguageLevel LanguageLevel { get; private set; }

    public Guid EnrollmentId { get; set; }
    public Enrollment Enrollment { get; set; }

    private Applicant(Guid id)
        : base(id)
    {
    }

    private Applicant(Guid id, string firstName, string lastName, Date birthDate,
        EducationDetails educationDetails, LanguageLevel languageLevel)
        : this(id)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        EducationDetails = educationDetails;
        LanguageLevel = languageLevel;
    }

    public static Applicant Create(Guid id, string firstName, string lastName, DateTime birthDate,
        string school, string grade, string levelKey)
    {
        var date = new Date(birthDate);
        var education = EducationDetails.Create(Education.FromName(school), grade);
        var languageLevel = LanguageLevel.Create(Level.FromKey(levelKey));

        return new Applicant(id, firstName, lastName, date, education, languageLevel);
    }
}