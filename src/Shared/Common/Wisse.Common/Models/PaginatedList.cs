namespace Wisse.Common.Models;

public class PaginatedList<T> where T : class
{
    private PaginatedList(Pagination pagination, IReadOnlyList<T> data)
    {
        Pagination = PaginationResponse.Create(pagination.PageIndex, pagination.PageSize, data.Count);
        Data = data;
    }

    private PaginatedList(PaginationResponse pagination, IReadOnlyList<T> data)
    {
        Pagination = pagination;
        Data = data;
    }

    public PaginationResponse Pagination { get; set; }
    public IReadOnlyList<T> Data { get; set; }

    public static PaginatedList<T> Create(Pagination pagination, IEnumerable<T> list)
    {
        var enumerable = list as T[] ?? list.ToArray();

        return new PaginatedList<T>(
            pagination,
            enumerable.ToList());
    }

    public static PaginatedList<T> Create(PaginationResponse pagination, IEnumerable<T> list)
    {
        var enumerable = list as T[] ?? list.ToArray();

        return new PaginatedList<T>(
            pagination,
            enumerable.ToList());
    }
}