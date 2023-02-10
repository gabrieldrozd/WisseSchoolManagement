using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wisse.Common.Controllers;
using Wisse.Common.Controllers.Types;
using Wisse.Modules.Users.Api.Controllers.Base;
using Wisse.Modules.Users.Application.Features.Auth.Commands;
using Wisse.Shared.Abstractions.Communication.Internal.Commands;

namespace Wisse.Modules.Users.Api.Controllers;

[ControllerConfiguration(ControllerType.Commands, UsersModule.Areas.Auth, UsersModule.BasePath + "/auth")]
internal sealed class AuthController : ModuleController
{
    private readonly ICommandDispatcher _commandDispatcher;

    public AuthController(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }

    [HttpPost]
    [ProducesEmptyEnvelope(StatusCodes.Status200OK)]
    public async Task<IActionResult> Submit(
        [FromBody] LoginUser command,
        CancellationToken cancellationToken = default)
    {
        var result = await _commandDispatcher.SendAsync(command, cancellationToken);
        return BuildEnvelope(result);
    }
}
