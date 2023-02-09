using System.Text.RegularExpressions;
using Wisse.Common.Domain.Primitives;
using Wisse.Common.Exceptions.ValueObjects.Email;

namespace Wisse.Common.Domain.ValueObjects;

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
            throw new InvalidEmailFormatException(value);
        }

        Value = value;
    }

    public static implicit operator string(Email email)
        => email.Value;

    public static implicit operator Email(string email)
        => new(email);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    [GeneratedRegex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$")]
    private partial Regex EmailRegex();
}
