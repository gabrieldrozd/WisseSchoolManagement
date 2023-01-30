using Wisse.Common.Models.Pagination.Core;

namespace Wisse.Common.Extensions;

public static class PaginatedListExtensions
{
    public static PaginatedList<TMapped> MapTo<TCurrent, TMapped>(
        this PaginatedList<TCurrent> current,
        Func<TCurrent, TMapped> func,
        bool mapNulls = false)
        where TCurrent : class
        where TMapped : class
    {
        var pagination = current.Pagination;
        var mapped = current.Data.MapTo(func, mapNulls);

        return PaginatedList<TMapped>.Create(pagination, mapped);
    }
}