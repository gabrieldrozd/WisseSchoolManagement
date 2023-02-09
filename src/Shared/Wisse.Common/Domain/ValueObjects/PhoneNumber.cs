using System.Text.RegularExpressions;
using Wisse.Common.Domain.Primitives;
using Wisse.Common.Exceptions.ValueObjects.PhoneNumber;

namespace Wisse.Common.Domain.ValueObjects;

public partial class PhoneNumber : ValueObject
{
    public string Value { get; }

    public PhoneNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyPhoneNumberException();
        }

        if (!PhoneRegex().IsMatch(value))
        {
            throw new InvalidPhoneNumberException();
        }

        Value = value;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    [GeneratedRegex(
        "(?:(?:(?:\\+|00)?48)|(?:\\(\\+?48\\)))?(?:1[2-8]|2[2-69]|3[2-49]|4[1-8]|5[0-9]|6[0-35-9]|[7-8][1-9]|9[145])\\d{7}")]
    private partial Regex PhoneRegex();
}