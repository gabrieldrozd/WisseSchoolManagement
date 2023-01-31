using Microsoft.AspNetCore.Mvc;

namespace Wisse.Modules.Users.Api.Controllers.Base;

internal class HomeController : ModuleController
{
    [HttpGet]
    public IActionResult Get() => Ok("Users module API");
}