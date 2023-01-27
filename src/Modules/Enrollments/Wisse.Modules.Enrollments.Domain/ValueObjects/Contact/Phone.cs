using System.Text.RegularExpressions;
using Wisse.Common.Domain.Primitives;
using Wisse.Modules.Enrollments.Domain.Exceptions.ValueObjects.Contact.Phone;

namespace Wisse.Modules.Enrollments.Domain.ValueObjects.Contact;

public partial class Phone : ValueObject
{
    public string Value { get; }

    public Phone(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyPhoneException();
        }

        if (!PhoneRegex().IsMatch(value))
        {
            throw new InvalidPhoneException();
        }

        Value = value;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    [GeneratedRegex(
        "(?:(?:(?:\\+|00)?48)|(?:\\(\\+?48\\)))?(?:1[2-8]|2[2-69]|3[2-49]|4[1-8]|5[0-9]|6[0-35-9]|[7-8][1-9]|9[145])\\d{7}")]
    private static partial Regex PhoneRegex();
}