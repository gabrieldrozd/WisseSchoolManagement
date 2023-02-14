using System.Reflection;

namespace Wisse.Base.Types;

public abstract class ObjectEnumeration<TEnum, TKey> : IEquatable<ObjectEnumeration<TEnum, TKey>>
    where TEnum : ObjectEnumeration<TEnum, TKey>
{
    private static readonly Dictionary<int, TEnum> Enumerations = CreateEnumerations();

    public TKey Key { get; protected init; }

    protected ObjectEnumeration(TKey type)
    {
        Key = type;
    }

    public static TEnum FromKey(TKey key)
        => Enumerations.Values.SingleOrDefault(x => x.Key.Equals(key));

    public bool Equals(ObjectEnumeration<TEnum, TKey> other)
    {
        if (other is null)
        {
            return false;
        }

        return GetType() == other.GetType() &&
               Key.Equals(other.Key);
    }

    public override bool Equals(object obj)
    {
        return obj is ObjectEnumeration<TEnum, TKey> other &&
               Equals(other);
    }

    public override int GetHashCode()
    {
        return Key.GetHashCode();
    }

    public override string ToString()
    {
        return Key.ToString();
    }

    private static Dictionary<int, TEnum> CreateEnumerations()
    {
        var enumerationKey = typeof(TEnum);

        var fieldsForKey = enumerationKey
            .GetFields(
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.FlattenHierarchy)
            .Where(fieldInfo =>
                enumerationKey.IsAssignableFrom(fieldInfo.FieldType))
            .Select(fieldInfo =>
                (TEnum) fieldInfo.GetValue(default));

        return fieldsForKey.ToDictionary(x => x!.GetHashCode());
    }
}