namespace Wisse.Common.Models;

public class PaginatedList<T> where T : class
{
    public PaginatedList(int pageIndex, int pageSize, int count, IReadOnlyList<T> data)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
        Count = count;
        Data = data;
    }

    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public int Count { get; set; }
    public bool HasPreviousPage => PageIndex > 1;
    public bool HasNextPage => PageSize * PageIndex < Count;
    public IReadOnlyList<T> Data { get; set; }
}