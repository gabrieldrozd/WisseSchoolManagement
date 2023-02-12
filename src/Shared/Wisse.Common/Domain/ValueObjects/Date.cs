using Wisse.Common.Domain.Primitives;

namespace Wisse.Common.Domain.ValueObjects;

public sealed class Date : ValueObject
{
    public DateTimeOffset Value { get; }

    public Date(DateTimeOffset value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public DateTime ToDateTime() => Value.DateTime;

    public long ToUnixSeconds() => Value.ToUnixTimeSeconds();

    public long ToUnixMilliseconds() => Value.ToUnixTimeMilliseconds();

    public Date AddMinutes(int minutes) => Value.AddMinutes(minutes);

    public Date AddDays(int days) => new(Value.AddDays(days));

    public Date AddMonths(int months) => new(Value.AddMonths(months));

    public static implicit operator DateTimeOffset(Date date)
        => date.Value;

    public static implicit operator Date(DateTimeOffset value)
        => new(value);

    public static bool operator <(Date first, Date second)
        => first.Value < second.Value;

    public static bool operator >(Date first, Date second)
        => first.Value > second.Value;

    public static bool operator <=(Date first, Date second)
        => first.Value <= second.Value;

    public static bool operator >=(Date first, Date second)
        => first.Value >= second.Value;

    public static Date Now => new(DateTimeOffset.Now);
}