using System.Reflection;

namespace Wisse.Base.Types;

public abstract class CollectionEnumeration<TEnum, TType> : IEquatable<CollectionEnumeration<TEnum, TType>>
    where TEnum : CollectionEnumeration<TEnum, TType>
{
    private static readonly Dictionary<int, TEnum> Enumerations = CreateEnumerations();

    public int Value { get; protected init; }
    public string Name { get; protected init; }

    public TType[] Collection { get; protected init; }

    protected CollectionEnumeration(int value, string name, TType[] collection)
    {
        Value = value;
        Name = name;
        Collection = collection;
    }

    public static TEnum FromValue(int value)
    {
        return Enumerations.TryGetValue(value, out var enumeration)
            ? enumeration
            : default;
    }

    public static TEnum FromName(string name)
    {
        return Enumerations.Values.SingleOrDefault(x => x.Name == name);
    }

    public bool Equals(CollectionEnumeration<TEnum, TType> other)
    {
        if (other is null)
        {
            return false;
        }

        return GetType() == other.GetType() &&
               Value == other.Value;
    }

    public override bool Equals(object obj)
    {
        return obj is CollectionEnumeration<TEnum, TType> other &&
               Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public override string ToString()
    {
        return Name;
    }

    private static Dictionary<int, TEnum> CreateEnumerations()
    {
        var enumerationType = typeof(TEnum);

        var fieldsForType = enumerationType
            .GetFields(
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.FlattenHierarchy)
            .Where(fieldInfo =>
                enumerationType.IsAssignableFrom(fieldInfo.FieldType))
            .Select(fieldInfo =>
                (TEnum)fieldInfo.GetValue(default));

        return fieldsForType.ToDictionary(x => x!.Value);
    }
}