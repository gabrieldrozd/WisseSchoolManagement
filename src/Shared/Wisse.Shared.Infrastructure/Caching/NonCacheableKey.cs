using Wisse.Base.Types;

namespace Wisse.Shared.Infrastructure.Caching;

public class NonCacheableKey : Enumeration<NonCacheableKey>
{
    public static readonly NonCacheableKey Users = new(1, "Users-GetCurrentUser");

    private NonCacheableKey(int value, string name) : base(value, name)
    {
    }

    public static bool IsKeyCacheable(string name)
    {
        return FromName(name) is null;
    }
}
