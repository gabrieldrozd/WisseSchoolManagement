using Wisse.Common.Models.Pagination.Shared;

namespace Wisse.Common.Models.Pagination.Core;

public class PaginatedList<T> where T : class
{
    public PaginationInfo Pagination { get; set; }
    public IReadOnlyList<T> Data { get; set; }

    private PaginatedList(Pagination pagination, IReadOnlyList<T> data)
    {
        Pagination = PaginationInfo.Create(pagination.PageIndex, pagination.PageSize, data.Count);
        Data = data;
    }

    private PaginatedList(PaginationInfo pagination, IReadOnlyList<T> data)
    {
        Pagination = pagination;
        Data = data;
    }

    public static PaginatedList<T> Create(Pagination pagination, IEnumerable<T> list)
    {
        var enumerable = list as T[] ?? list.ToArray();

        return new PaginatedList<T>(
            pagination,
            enumerable.ToList());
    }

    public static PaginatedList<T> Create(PaginationInfo pagination, IEnumerable<T> list)
    {
        var enumerable = list as T[] ?? list.ToArray();

        return new PaginatedList<T>(
            pagination,
            enumerable.ToList());
    }
}