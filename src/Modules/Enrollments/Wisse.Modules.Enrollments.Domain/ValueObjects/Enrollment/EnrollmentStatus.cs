using Wisse.Common.Domain.Primitives;
using Wisse.Modules.Enrollments.Domain.Exceptions.ValueObjects.Enrollment;

namespace Wisse.Modules.Enrollments.Domain.ValueObjects.Enrollment;

public class EnrollmentStatus : ValueObject
{
    public const string Pending = nameof(Pending);
    public const string Approved = nameof(Approved);
    public const string Rejected = nameof(Rejected);

    public string Value { get; }

    public EnrollmentStatus(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyEnrollmentStatusException();
        }

        if (!IsValid(value))
        {
            throw new InvalidEnrollmentStatusException();
        }

        Value = value;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    private static bool IsValid(string status)
        => status is Pending or Approved or Rejected;
}
