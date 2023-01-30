using System.Reflection;
using Wisse.Common.Constants;

namespace Wisse.Common.Types;

public abstract class ErrorEnumeration<TEnum> : IEquatable<ErrorEnumeration<TEnum>>
    where TEnum : ErrorEnumeration<TEnum>
{
    private static readonly Dictionary<int, TEnum> Enumerations = CreateEnumerations();

    public string Code { get; }
    public string Message { get; }

    protected ErrorEnumeration(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public static TEnum FromCode(string code)
    {
        return Enumerations.Values.SingleOrDefault(x => x.Code == code);
    }

    public bool Equals(ErrorEnumeration<TEnum> other)
    {
        if (other is null)
        {
            return false;
        }

        return GetType() == other.GetType() &&
               Code == other.Code &&
               Message == other.Message;
    }

    public override bool Equals(object obj)
    {
        return obj is ErrorEnumeration<TEnum> other &&
               Equals(other);
    }

    public override int GetHashCode()
    {
        return Code.GetHashCode();
    }

    public override string ToString()
    {
        return Code;
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
                (TEnum) fieldInfo.GetValue(default));

        return fieldsForType.ToDictionary(x => x!.Code.GetHashCode());
    }
}