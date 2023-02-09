using System.Reflection;

namespace Wisse.Base.Types;

public abstract class PairEnumeration<TEnum> : IEquatable<PairEnumeration<TEnum>>
    where TEnum : PairEnumeration<TEnum>
{
    private static readonly Dictionary<int, TEnum> Enumerations = CreateEnumerations();

    public string Key { get; protected init; }
    public string Name { get; protected init; }

    protected PairEnumeration(string key, string name)
    {
        Key = key;
        Name = name;
    }

    public static TEnum FromKey(string key)
    {
        return Enumerations.Values.SingleOrDefault(x => x.Key == key);
    }

    public static TEnum FromName(string name)
    {
        return Enumerations.Values.SingleOrDefault(x => x.Name == name);
    }

    public bool Equals(PairEnumeration<TEnum> other)
    {
        if (other is null)
        {
            return false;
        }

        return GetType() == other.GetType() && Key == other.Key;
    }

    public override bool Equals(object obj)
    {
        return obj is PairEnumeration<TEnum> other &&
               Equals(other);
    }

    public override int GetHashCode()
    {
        return Key.GetHashCode();
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

        return fieldsForType.ToDictionary(x => x!.Key.GetHashCode());
    }
}