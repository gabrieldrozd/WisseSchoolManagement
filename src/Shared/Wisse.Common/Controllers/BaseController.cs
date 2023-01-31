using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wisse.Base.Results;
using Wisse.Common.Extensions;
using Wisse.Common.Models.Envelope;

namespace Wisse.Common.Controllers;

[ApiController]
[ProducesDefaultContentType]
public abstract class BaseController : ControllerBase
{
    [ProducesEmptyEnvelope(StatusCodes.Status400BadRequest)]
    [ProducesEmptyEnvelope(StatusCodes.Status404NotFound)]
    [ProducesEmptyEnvelope(StatusCodes.Status500InternalServerError)]
    protected IActionResult BuildEnvelope(Result result)
    {
        var statusCode = result.GetStatusCode();
        var envelope = result.ToEnvelope();

        return StatusCode(statusCode, envelope);
    }

    [ProducesEmptyEnvelope(StatusCodes.Status400BadRequest)]
    [ProducesEmptyEnvelope(StatusCodes.Status404NotFound)]
    [ProducesEmptyEnvelope(StatusCodes.Status500InternalServerError)]
    protected IActionResult BuildEnvelope<T>(Result<T> result)
    {
        var statusCode = result.GetStatusCode();
        var envelope = result.ToEnvelope();

        return StatusCode(statusCode, envelope);
    }
}
