using Microsoft.AspNetCore.Mvc;

namespace Wisse.Modules.Enrollments.Api.Controllers.Base;

internal sealed class HomeController : ModuleController
{
    [HttpGet]
    public IActionResult Get() => Ok("Enrollments module API");
}