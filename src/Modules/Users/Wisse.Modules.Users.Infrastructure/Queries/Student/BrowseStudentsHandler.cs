using Wisse.Base.Results;
using Wisse.Common.Extensions;
using Wisse.Common.Models.Pagination;
using Wisse.Modules.Users.Application.DTO.Queries.Student;
using Wisse.Modules.Users.Application.Features.Students.Queries;
using Wisse.Modules.Users.Application.Mappings;
using Wisse.Modules.Users.Domain.Interfaces.Repositories;
using Wisse.Shared.Abstractions.Communication.Internal.Queries;

namespace Wisse.Modules.Users.Infrastructure.Queries.Student;

internal sealed class BrowseStudentsHandler : IQueryHandler<BrowseStudents, PaginatedList<StudentDto>>
{
    private readonly IQueryStudentRepository _queryStudentRepository;

    public BrowseStudentsHandler(IQueryStudentRepository queryStudentRepository)
    {
        _queryStudentRepository = queryStudentRepository;
    }

    public async Task<Result<PaginatedList<StudentDto>>> HandleAsync(
        BrowseStudents query, CancellationToken cancellationToken = default)
    {
        var students = await _queryStudentRepository.BrowseAsync(query.Pagination, cancellationToken);
        var mapped = students.MapTo(StudentMappings.ToStudentDto);

        return Result.Success(mapped);
    }
}
