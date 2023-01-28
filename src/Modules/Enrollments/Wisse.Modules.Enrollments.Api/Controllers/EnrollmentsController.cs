using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wisse.Modules.Enrollments.Api.Controllers.Base;
using Wisse.Modules.Enrollments.Application.DTO.Enrollment;
using Wisse.Modules.Enrollments.Application.Features.Queries;

namespace Wisse.Modules.Enrollments.Api.Controllers;

internal class EnrollmentsController : ModuleController
{
    private readonly ISender _sender;

    public EnrollmentsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{enrollmentId:guid}")]
    public async Task<ActionResult<EnrollmentDetailsDto>> GetDetails([FromRoute] Guid enrollmentId)
    {
        var query = new GetEnrollmentDetails(enrollmentId);
        var result = await _sender.Send(query);

        // TODO: Create a custom response type for DataResult<T> and additional information like:
        // - Errors
        // - StatusCode
        // and maybe something else
        return Ok(result);
    }
}