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

        if (!IsPhoneNumberValid(value))
        {
            throw new InvalidPhoneNumberException();
        }

        Value = value;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    private static bool IsPhoneNumberValid(string phoneNumber)
    {
        var regex = new Regex(@"^(?:\+?48)?(?:[ -]?[0-9]){9}$");
        return regex.IsMatch(phoneNumber);
    }
}