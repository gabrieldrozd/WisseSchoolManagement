using Microsoft.AspNetCore.Mvc;

namespace Wisse.Modules.Users.Api.Controllers.Base;

internal sealed class HomeController : ModuleController
{
    [HttpGet]
    public IActionResult Get() => Ok("Users module API");
}