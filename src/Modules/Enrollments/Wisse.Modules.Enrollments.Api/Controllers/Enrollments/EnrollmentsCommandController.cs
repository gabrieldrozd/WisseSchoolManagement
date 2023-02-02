using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wisse.Common.Controllers;
using Wisse.Common.Controllers.Types;
using Wisse.Modules.Enrollments.Api.Controllers.Base;
using Wisse.Modules.Enrollments.Application.Features.Commands;
using Wisse.Shared.Abstractions.Communication.Internal.Commands;
using Wisse.Shared.Infrastructure.Api.Settings;

namespace Wisse.Modules.Enrollments.Api.Controllers.Enrollments;

[ControllerConfiguration(ControllerType.Commands, EnrollmentsModule.Areas.Enrollments, EnrollmentsModule.BasePath)]
internal class EnrollmentsCommandController : ModuleController
{
    private readonly ICommandDispatcher _commandDispatcher;

    public EnrollmentsCommandController(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }

    [HttpPost]
    [ProducesEmptyEnvelope(StatusCodes.Status200OK)]
    public async Task<IActionResult> Submit(
        [FromBody] SubmitEnrollment command,
        CancellationToken cancellationToken = default)
    {
        var result = await _commandDispatcher.SendAsync(command, cancellationToken);
        return BuildEnvelope(result);
    }

    [HttpPut("{enrollmentId:guid}/approve")]
    [ProducesEmptyEnvelope(StatusCodes.Status200OK)]
    public async Task<IActionResult> Approve(
        [FromRoute] Guid enrollmentId,
        CancellationToken cancellationToken = default)
    {
        var command = new ApproveEnrollment(enrollmentId);
        var result = await _commandDispatcher.SendAsync(command, cancellationToken);
        return BuildEnvelope(result);
    }

    [HttpPut("{enrollmentId:guid}/reject")]
    [ProducesEmptyEnvelope(StatusCodes.Status200OK)]
    public async Task<IActionResult> Reject(
        [FromRoute] Guid enrollmentId,
        CancellationToken cancellationToken = default)
    {
        var command = new RejectEnrollment(enrollmentId);
        var result = await _commandDispatcher.SendAsync(command, cancellationToken);
        return BuildEnvelope(result);
    }
}