using Wisse.Base.Results;
using Wisse.Common.Extensions;
using Wisse.Common.Models.Pagination;
using Wisse.Modules.Users.Application.DTO.Queries.Teacher;
using Wisse.Modules.Users.Application.Features.Teachers.Queries;
using Wisse.Modules.Users.Application.Mappings;
using Wisse.Modules.Users.Domain.Interfaces.Repositories;
using Wisse.Shared.Abstractions.Communication.Internal.Queries;

namespace Wisse.Modules.Users.Infrastructure.Queries.Teacher;

internal sealed class BrowseTeachersHandler : IQueryHandler<BrowseTeachers, PaginatedList<TeacherDto>>
{
    private readonly IQueryTeacherRepository _queryTeacherRepository;

    public BrowseTeachersHandler(IQueryTeacherRepository queryTeacherRepository)
    {
        _queryTeacherRepository = queryTeacherRepository;
    }

    public async Task<Result<PaginatedList<TeacherDto>>> HandleAsync(
        BrowseTeachers query, CancellationToken cancellationToken = default)
    {
        var teachers = await _queryTeacherRepository.BrowseAsync(query.Pagination, cancellationToken);
        var mapped = teachers.MapTo(TeacherMappings.ToTeacherDto);

        return Result.Success(mapped);
    }
}
