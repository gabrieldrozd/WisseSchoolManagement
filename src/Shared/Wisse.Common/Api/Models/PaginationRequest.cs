using Wisse.Common.Constants;
using Wisse.Common.Models.Pagination.Core;

namespace Wisse.Common.Api.Models;

public class PaginationRequest
{
    public int PageSize { get; set; } = PaginationConstants.DefaultPageSize;
    public int PageIndex { get; set; } = PaginationConstants.DefaultPageIndex;

    public Pagination ToPagination() => new(PageSize, PageIndex);
}
