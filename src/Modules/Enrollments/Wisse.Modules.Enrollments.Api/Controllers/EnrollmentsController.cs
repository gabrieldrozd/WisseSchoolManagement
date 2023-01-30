using Microsoft.AspNetCore.Mvc;
using Wisse.Common.Api.Requests;
using Wisse.Common.Models;
using Wisse.Common.Results;
using Wisse.Modules.Enrollments.Api.Controllers.Base;
using Wisse.Modules.Enrollments.Application.DTO.Queries.Enrollment;
using Wisse.Modules.Enrollments.Application.Features.Commands;
using Wisse.Modules.Enrollments.Application.Features.Queries;
using Wisse.Shared.Abstractions.Mediator.Commands;
using Wisse.Shared.Abstractions.Mediator.Queries;

namespace Wisse.Modules.Enrollments.Api.Controllers;

internal class EnrollmentsController : ModuleController
{
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly ICommandDispatcher _commandDispatcher;

    public EnrollmentsController(
        IQueryDispatcher queryDispatcher,
        ICommandDispatcher commandDispatcher)
    {
        _queryDispatcher = queryDispatcher;
        _commandDispatcher = commandDispatcher;
    }

    #region Query

    [HttpGet("{enrollmentId:guid}")]
    public async Task<ActionResult<Result<EnrollmentDetailsDto>>> GetDetails(
        [FromRoute] Guid enrollmentId,
        CancellationToken cancellationToken = default)
    {
        var query = new GetEnrollmentDetails(enrollmentId);
        var result = await _queryDispatcher.QueryAsync(query, cancellationToken);

        // TODO: Create a custom response type for DataResult<T> and additional information like:
        // - Errors
        // - StatusCode
        // and maybe something else
        return Ok(result);
    }

    [HttpPut("browse")]
    public async Task<ActionResult<PaginatedList<EnrollmentDto>>> Browse(
        [FromBody] PaginationRequest pagination,
        CancellationToken cancellationToken = default)
    {
        var query = new BrowseEnrollments(pagination.ToPagination());
        var results = await _queryDispatcher.QueryAsync(query, cancellationToken);

        return Ok(results);
    }

    #endregion

    #region Command

    [HttpPost]
    public async Task<ActionResult> Submit(
        [FromBody] SubmitEnrollment command,
        CancellationToken cancellationToken = default)
    {
        await _commandDispatcher.SendAsync(command, cancellationToken);

        // TODO: Create a custom response type for DataResult<T> and additional information like:
        // - Errors
        // - StatusCode
        // and maybe something else
        // Result is being returned so good idea is to return it as a response

        return CreatedAtAction(nameof(GetDetails), new { enrollmentId = command.Enrollment.Id }, null);
    }

    #endregion
}