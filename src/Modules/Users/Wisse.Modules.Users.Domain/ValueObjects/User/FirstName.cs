using Wisse.Common.Domain.Primitives;
using Wisse.Modules.Users.Domain.Exceptions.ValueObjects.User;

namespace Wisse.Modules.Users.Domain.ValueObjects.User;

public class FirstName : ValueObject
{
    public string Value { get; set; }

    public FirstName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyFirstNameException();
        }

        Value = value;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}