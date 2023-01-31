namespace Wisse.Common.Models.Pagination;

public class PaginationInfo
{
    public int PageIndex { get; }
    public int PageSize { get; }
    public int TotalItems { get; }
    public int Count { get; }
    public bool HasPreviousPage => PageIndex > 1;
    public bool HasNextPage => PageSize * PageIndex < TotalItems;

    private PaginationInfo(int pageIndex, int pageSize, int totalItems, int count)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
        TotalItems = totalItems;
        Count = count;
    }

    public static PaginationInfo Create(int pageIndex, int pageSize, int totalItems, int count)
        => new(pageIndex, pageSize, totalItems, count);
}