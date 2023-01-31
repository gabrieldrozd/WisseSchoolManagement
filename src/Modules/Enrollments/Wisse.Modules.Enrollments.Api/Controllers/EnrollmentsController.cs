using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wisse.Common.Controllers;
using Wisse.Common.Models.Envelope;
using Wisse.Common.Models.Pagination;
using Wisse.Modules.Enrollments.Api.Controllers.Base;
using Wisse.Modules.Enrollments.Application.DTO.Queries.Enrollment;
using Wisse.Modules.Enrollments.Application.Features.Commands;
using Wisse.Modules.Enrollments.Application.Features.Queries;
using Wisse.Shared.Abstractions.Messaging.Mediator.Commands;
using Wisse.Shared.Abstractions.Messaging.Mediator.Queries;

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

    #endregion

    #region Command

    [HttpPost]
    [ProducesEmptyEnvelope(StatusCodes.Status200OK)]
    public async Task<IActionResult> Submit(
        [FromBody] SubmitEnrollment command,
        CancellationToken cancellationToken = default)
    {
        var result = await _commandDispatcher.SendAsync(command, cancellationToken);
        return BuildEnvelope(result);
    }

    #endregion
}