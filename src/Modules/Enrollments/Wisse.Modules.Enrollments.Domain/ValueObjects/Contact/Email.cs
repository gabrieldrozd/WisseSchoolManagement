using System.Text.RegularExpressions;
using Wisse.Common.Domain.Primitives;
using Wisse.Modules.Enrollments.Domain.Exceptions.ValueObjects.Contact;

namespace Wisse.Modules.Enrollments.Domain.ValueObjects.Contact;

public partial class Email : ValueObject
{
    public string Value { get; }

    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyEmailException();
        }

        if (!EmailRegex().IsMatch(value))
        {
            throw new InvalidEmailException();
        }

        Value = value;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    [GeneratedRegex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$")]
    private static partial Regex EmailRegex();
}