using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wisse.Common.Auth;
using Wisse.Common.Controllers;
using Wisse.Common.Controllers.Types;
using Wisse.Common.Models.Pagination;
using Wisse.Modules.Users.Api.Controllers.Base;
using Wisse.Modules.Users.Application.DTO.Queries.Teacher;
using Wisse.Modules.Users.Application.Features.Teachers.Queries;
using Wisse.Shared.Abstractions.Communication.Internal.Queries;
using Wisse.Shared.Infrastructure.Auth.Api.Permissions;
using Wisse.Shared.Infrastructure.Auth.Api.Roles;

namespace Wisse.Modules.Users.Api.Controllers.Teachers;

[ControllerConfiguration(ControllerType.Queries, UsersModule.Areas.Teachers, UsersModule.BasePath + "/teachers")]
internal sealed class TeachersQueryController : ModuleController
{
    private readonly IQueryDispatcher _queryDispatcher;

    public TeachersQueryController(IQueryDispatcher queryDispatcher)
    {
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet("{teacherId:guid}")]
    [RoleRequirement(RoleKey.Admin)]
    [PermissionRequirement(PermissionKey.Read)]
    [ProducesEnvelope(typeof(TeacherDetailsDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDetails(
        [FromRoute] Guid teacherId,
        CancellationToken cancellationToken = default)
    {
        var query = new GetTeacherDetails(teacherId);
        var result = await _queryDispatcher.QueryAsync(query, cancellationToken);
        return BuildEnvelope(result);
    }

    [HttpPut("browse")]
    [RoleRequirement(RoleKey.Admin)]
    [PermissionRequirement(PermissionKey.Read)]
    [ProducesEnvelope(typeof(PaginatedList<TeacherDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Browse(
        [FromBody] PaginationRequest pagination,
        CancellationToken cancellationToken = default)
    {
        var query = new BrowseTeachers(pagination.ToPagination());
        var result = await _queryDispatcher.QueryAsync(query, cancellationToken);
        return BuildEnvelope(result);
    }
}
