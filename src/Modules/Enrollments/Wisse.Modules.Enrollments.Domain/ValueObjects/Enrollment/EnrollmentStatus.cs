using Wisse.Common.Domain.Primitives;
using Wisse.Modules.Enrollments.Domain.Constants;
using Wisse.Modules.Enrollments.Domain.Exceptions.ValueObjects.Enrollment;

namespace Wisse.Modules.Enrollments.Domain.ValueObjects.Enrollment;

public class EnrollmentStatus : ValueObject
{
    public string Value { get; }

    public EnrollmentStatus(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new EmptyEnrollmentStatusException();

        if (!Status.IsValid(value))
            throw new InvalidEnrollmentStatusException();

        Value = value;
    }

    public static EnrollmentStatus Create(Status status)
        => new(status.Name);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
