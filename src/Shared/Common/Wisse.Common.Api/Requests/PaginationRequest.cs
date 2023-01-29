using Wisse.Common.Constants;
using Wisse.Common.Models;

namespace Wisse.Common.Api.Requests;

public class PaginationRequest
{
    public int PageSize { get; set; } = PaginationConstants.DefaultPageSize;
    public int PageIndex { get; set; } = PaginationConstants.DefaultPageIndex;

    public Models.Pagination ToPagination() => new(PageSize, PageIndex);
}
