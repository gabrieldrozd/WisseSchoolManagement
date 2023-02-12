using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wisse.Common.Controllers;
using Wisse.Common.Controllers.Types;
using Wisse.Modules.Users.Api.Controllers.Base;
using Wisse.Modules.Users.Application.Features.Auth.Commands;
using Wisse.Modules.Users.Application.Features.Auth.Queries;
using Wisse.Shared.Abstractions.Auth;
using Wisse.Shared.Abstractions.Communication.Internal.Commands;
using Wisse.Shared.Abstractions.Communication.Internal.Queries;

namespace Wisse.Modules.Users.Api.Controllers;

[ControllerConfiguration(ControllerType.Commands, UsersModule.Areas.Auth, UsersModule.BasePath + "/auth")]
internal sealed class AuthController : ModuleController
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public AuthController(
        ICommandDispatcher commandDispatcher,
        IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [Authorize]
    [HttpGet]
    [ProducesEmptyEnvelope(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(CancellationToken cancellationToken = default)
    {
        var query = new GetCurrentUser();
        var result = await _queryDispatcher.QueryAsync(query, cancellationToken);
        return BuildEnvelope(result);
    }

    [HttpPost]
    [ProducesEmptyEnvelope(StatusCodes.Status200OK)]
    public async Task<IActionResult> Submit(
        [FromBody] LoginUser command,
        CancellationToken cancellationToken = default)
    {
        var result = await _commandDispatcher.SendAsync<LoginUser, AccessToken>(command, cancellationToken);
        return BuildEnvelope(result);
    }
}