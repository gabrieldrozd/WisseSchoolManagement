using Wisse.Common.Domain.Primitives;
using Wisse.Modules.Users.Domain.Exceptions.ValueObjects.User;

namespace Wisse.Modules.Users.Domain.ValueObjects.User;

public class LastName : ValueObject
{
    public string Value { get; set; }

    public LastName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyLastNameException();
        }

        Value = value;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}