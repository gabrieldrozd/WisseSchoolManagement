using Wisse.Common.Domain.Primitives;
using Wisse.Common.Domain.ValueObjects;
using Wisse.Modules.Enrollments.Domain.ValueObjects.Applicant;

namespace Wisse.Modules.Enrollments.Domain.Entities;

public class Applicant : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Date BirthDate { get; set; }

    public EducationDetails EducationDetails { get; set; }
    public LanguageLevel LanguageLevel { get; set; }

    public Applicant(Guid id) // TODO: Constructors like in Enrollment PLUS factory method for creating new Applicant
        : base(id)
    {
    }
}