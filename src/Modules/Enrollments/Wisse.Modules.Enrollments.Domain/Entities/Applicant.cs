using Wisse.Common.Domain.Primitives;
using Wisse.Common.Domain.ValueObjects;

namespace Wisse.Modules.Enrollments.Domain.Entities;

public class Applicant : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Date BirthDate { get; set; }

    // TODO: implement other properties such as School, Grade, LanguageLevel etc.
    // Consider using ValueObjects for these properties.

    public Applicant(Guid id)
        : base(id)
    {
    }
}