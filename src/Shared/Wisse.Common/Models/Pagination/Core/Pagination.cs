using Wisse.Common.Constants;

namespace Wisse.Common.Models.Pagination.Core;

public class Pagination
{
    public int PageSize { get; set; }
    public int PageIndex { get; set; }
    public int Skip => PageSize * (PageIndex - 1);

    public Pagination()
    {
        PageSize = PaginationConstants.DefaultPageSize;
        PageIndex = PaginationConstants.DefaultPageIndex;
    }

    public Pagination(int pageSize, int pageIndex)
    {
        PageSize = pageSize is < PaginationConstants.MinPageSize or > PaginationConstants.MaxPageSize
            ? PaginationConstants.DefaultPageSize
            : pageSize;

        PageIndex = pageIndex is < PaginationConstants.MinPageIndex or > PaginationConstants.MaxPageIndex
            ? PaginationConstants.DefaultPageIndex
            : pageIndex;
    }
}