using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wisse.Common.Controllers;
using Wisse.Common.Controllers.Types;
using Wisse.Common.Models.Pagination;
using Wisse.Modules.Users.Api.Controllers.Base;
using Wisse.Modules.Users.Application.DTO.Queries.Student;
using Wisse.Modules.Users.Application.Features.Students.Queries;
using Wisse.Shared.Abstractions.Communication.Internal.Queries;

namespace Wisse.Modules.Users.Api.Controllers.Students;

[ControllerConfiguration(ControllerType.Queries, UsersModule.Areas.Students, UsersModule.BasePath + "/students")]
internal class StudentsQueryController : ModuleController
{
    private readonly IQueryDispatcher _queryDispatcher;

    public StudentsQueryController(IQueryDispatcher queryDispatcher)
    {
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet("{studentId:guid}")]
    [ProducesEnvelope(typeof(StudentDetailsDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDetails(
        [FromRoute] Guid studentId,
        CancellationToken cancellationToken = default)
    {
        var query = new GetStudentDetails(studentId);
        var result = await _queryDispatcher.QueryAsync(query, cancellationToken);
        return BuildEnvelope(result);
    }

    [HttpPut("browse")]
    [ProducesEnvelope(typeof(PaginatedList<StudentDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Browse(
        [FromBody] PaginationRequest pagination,
        CancellationToken cancellationToken = default)
    {
        var query = new BrowseStudents(pagination.ToPagination());
        var result = await _queryDispatcher.QueryAsync(query, cancellationToken);
        return BuildEnvelope(result);
    }
}
