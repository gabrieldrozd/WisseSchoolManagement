using Microsoft.AspNetCore.Mvc;

namespace Wisse.Common.Api.Controllers;

[ApiController]
[ProducesDefaultContentType]
public abstract class BaseController : ControllerBase
{
    protected ActionResult<T> OkOrNotFound<T>(T model)
    {
        if (model is null)
        {
            return NotFound();
        }

        return Ok(model);
    }
}
