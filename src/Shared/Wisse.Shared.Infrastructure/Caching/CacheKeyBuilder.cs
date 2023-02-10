using System.Reflection;
using Wisse.Common.Communication.Internal;
using Wisse.Common.Models.Attributes;

namespace Wisse.Shared.Infrastructure.Caching;

internal static class CacheKeyBuilder
{
    public static string BuildCacheKey<TResult>(this IQuery<TResult> query)
    {
        var queryName = query.GetType().Name;
        var entityName = GetEntityName(query);
        return $"{entityName}-{queryName}";
    }

    private static string GetEntityName(object query)
    {
        var queryType = query.GetType();
        var attribute = queryType.GetCustomAttribute<QueryEntityNameAttribute>();
        return attribute is not null
            ? attribute.EntityName
            : queryType.Name;
    }
}