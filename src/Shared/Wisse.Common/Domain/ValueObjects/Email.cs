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

        if (!IsEmailValid(value))
        {
            throw new InvalidEmailFormatException(value);
        }

        Value = value.ToLowerInvariant();
    }

    public static implicit operator string(Email email)
        => email.Value;

    public static implicit operator Email(string email)
        => new(email);

    public bool Equals(string otherEmail)
        => Value == otherEmail;

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    private static bool IsEmailValid(string email)
    {
        var regex = new Regex(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
        return regex.IsMatch(email);
    }
}
