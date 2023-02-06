using Microsoft.AspNetCore.Mvc;
using Wisse.Common.Controllers;
using Wisse.Common.Controllers.Types;
using Wisse.Modules.Users.Api.Controllers.Base;
using Wisse.Shared.Abstractions.Communication.Internal.Commands;

namespace Wisse.Modules.Users.Api.Controllers.Students;

[ControllerConfiguration(ControllerType.Commands, UsersModule.Areas.Students, UsersModule.BasePath + "/students")]
internal class StudentsCommandController : ModuleController
{
    private readonly ICommandDispatcher _commandDispatcher;

    public StudentsCommandController(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }

    [HttpPost]
    public async Task<IActionResult> Test(CancellationToken cancellationToken = default)
    {
        return Ok("test");
    }

    // TODO: Add basic student operations like update, delete, etc.
}