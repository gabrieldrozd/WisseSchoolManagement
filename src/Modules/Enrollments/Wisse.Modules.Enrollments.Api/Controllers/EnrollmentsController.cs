using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wisse.Common.Api.Requests;
using Wisse.Common.Models;
using Wisse.Common.Results;
using Wisse.Modules.Enrollments.Api.Controllers.Base;
using Wisse.Modules.Enrollments.Application.DTO.Enrollment;
using Wisse.Modules.Enrollments.Application.Features.Queries;
using Wisse.Shared.Abstractions.Mediator.Queries;

namespace Wisse.Modules.Enrollments.Api.Controllers;

internal class EnrollmentsController : ModuleController
{
    private readonly IQueryDispatcher _queryDispatcher;

    public EnrollmentsController(
        IQueryDispatcher queryDispatcher)
    {
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet("{enrollmentId:guid}")]
    public async Task<ActionResult<Result<EnrollmentDetailsDto>>> GetDetails([FromRoute] Guid enrollmentId)
    {
        var query = new GetEnrollmentDetails(enrollmentId);
        var result = await _queryDispatcher.QueryAsync(query);

        // TODO: Create a custom response type for DataResult<T> and additional information like:
        // - Errors
        // - StatusCode
        // and maybe something else
        return Ok(result);
    }

    [HttpPut("browse")]
    public async Task<ActionResult<PaginatedList<EnrollmentDto>>> Browse([FromBody] PaginationRequest pagination)
    {
        var query = new BrowseEnrollments(pagination.ToPagination());
        var results = await _queryDispatcher.QueryAsync(query);

        return Ok(results);
    }
}