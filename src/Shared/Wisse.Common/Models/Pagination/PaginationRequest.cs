using Wisse.Common.Constants;

namespace Wisse.Common.Models.Pagination;

public class PaginationRequest
{
    public int PageSize { get; set; } = PaginationConstants.DefaultPageSize;
    public int PageIndex { get; set; } = PaginationConstants.DefaultPageIndex;
    public bool IsAscending { get; set; } = PaginationConstants.DefaultOrderByAscending;

    public Pagination ToPagination() => new(PageSize, PageIndex, IsAscending);
}