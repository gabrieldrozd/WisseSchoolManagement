namespace Wisse.Common.Models.Pagination.Shared;

public class PaginationInfo
{
    public int PageIndex { get; }
    public int PageSize { get; }
    public int Count { get; }
    public bool HasPreviousPage => PageIndex > 1;
    public bool HasNextPage => PageSize * PageIndex < Count;

    private PaginationInfo(int pageIndex, int pageSize, int count)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
        Count = count;
    }

    public static PaginationInfo Create(int pageIndex, int pageSize, int count)
        => new(pageIndex, pageSize, count);
}