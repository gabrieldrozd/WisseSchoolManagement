namespace Wisse.Common.Extensions;

public static class CollectionExtensions
{
    public static bool HasOther<T>(this IEnumerable<T> source, IEnumerable<T> other)
    {
        var sourceEnumerable = source as T[] ?? source.ToArray();
        var otherEnumerable = other as T[] ?? other.ToArray();
        return sourceEnumerable.Any() && otherEnumerable.Any() &&
               sourceEnumerable.Intersect(otherEnumerable).Count() == otherEnumerable.Length;
    }

    public static bool HasOther<T>(this IEnumerable<T> source, T other)
    {
        var sourceEnumerable = source as T[] ?? source.ToArray();
        return sourceEnumerable.Any() && other is not null &&
               sourceEnumerable.Contains(other);
    }

    public static List<T1> MapTo<T, T1>(
        this IEnumerable<T> source, Func<T, T1> func, bool mapNulls = false)
    {
        if (mapNulls && source is null)
        {
            return null;
        }

        var enumerable = source as T[] ?? source.ToArray();
        return enumerable.IsNullOrEmpty()
            ? new List<T1>()
            : enumerable.Select(func).ToList();
    }

    public static List<T2> MapTo<T, T1, T2>(
        this IEnumerable<T> source, Func<T, T1, T2> func, T1 a, bool mapNulls = false)
    {
        if (mapNulls && source is null)
        {
            return null;
        }

        var enumerable = source as T[] ?? source.ToArray();
        return enumerable.IsNullOrEmpty()
            ? new List<T2>()
            : enumerable.Select(x => func(x, a)).ToList();
    }

    public static List<T3> MapTo<T, T1, T2, T3>(
        this IEnumerable<T> source, Func<T, T1, T2, T3> func, T1 a, T2 b, bool mapNulls = false)
    {
        if (mapNulls && source is null)
        {
            return null;
        }

        var enumerable = source as T[] ?? source.ToArray();
        return enumerable.IsNullOrEmpty()
            ? new List<T3>()
            : enumerable.Select(x => func(x, a, b)).ToList();
    }

    private static bool IsNullOrEmpty<T>(this IEnumerable<T> source) => !(source?.Any() ?? false);
}