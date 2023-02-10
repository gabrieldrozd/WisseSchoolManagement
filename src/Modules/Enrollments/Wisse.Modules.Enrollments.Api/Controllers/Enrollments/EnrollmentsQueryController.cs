using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wisse.Common.Controllers;
using Wisse.Common.Controllers.Types;
using Wisse.Common.Models.Pagination;
using Wisse.Modules.Enrollments.Api.Controllers.Base;
using Wisse.Modules.Enrollments.Application.DTO.Queries.Enrollment;
using Wisse.Modules.Enrollments.Application.Features.Queries;
using Wisse.Shared.Abstractions.Communication.Internal.Queries;

namespace Wisse.Modules.Enrollments.Api.Controllers.Enrollments;

[ControllerConfiguration(ControllerType.Queries, EnrollmentsModule.Areas.Enrollments, EnrollmentsModule.BasePath)]
internal sealed class EnrollmentsQueryController : ModuleController
{
    private readonly IQueryDispatcher _queryDispatcher;

    public EnrollmentsQueryController(IQueryDispatcher queryDispatcher)
    {
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet("{enrollmentId:guid}")]
    [ProducesEnvelope(typeof(EnrollmentDetailsDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDetails(
        [FromRoute] Guid enrollmentId,
        CancellationToken cancellationToken = default)
    {
        var query = new GetEnrollmentDetails(enrollmentId);
        var result = await _queryDispatcher.QueryAsync(query, cancellationToken);
        return BuildEnvelope(result);
    }

    [HttpPut("browse")]
    [ProducesEnvelope(typeof(PaginatedList<EnrollmentDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Browse(
        [FromBody] PaginationRequest pagination,
        CancellationToken cancellationToken = default)
    {
        var query = new BrowseEnrollments(pagination.ToPagination());
        var result = await _queryDispatcher.QueryAsync(query, cancellationToken);
        return BuildEnvelope(result);
    }
}