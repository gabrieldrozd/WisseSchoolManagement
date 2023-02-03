using System.Text.RegularExpressions;
using Wisse.Common.Domain.Primitives;
using Wisse.Modules.Users.Domain.Exceptions.ValueObjects.Contact;

namespace Wisse.Modules.Users.Domain.ValueObjects.Contact;

public partial class ZipCode : ValueObject
{
    public string Value { get; }

    public ZipCode(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyZipCodeException();
        }

        if (!ZipCodeRegex().IsMatch(value))
        {
            throw new InvalidZipCodeException();
        }

        Value = value;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    [GeneratedRegex("^[0-9]{2}[-\\s]*?[0-9]{3}$")]
    private static partial Regex ZipCodeRegex();
}
