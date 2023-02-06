using Wisse.Base.Results;
using Wisse.Modules.Users.Application.DTO.Queries.Student;
using Wisse.Modules.Users.Application.Features.Students.Queries;
using Wisse.Modules.Users.Application.Mappings;
using Wisse.Modules.Users.Domain.Entities;
using Wisse.Modules.Users.Domain.Interfaces.Repositories;
using Wisse.Shared.Abstractions.Communication.Internal.Queries;

namespace Wisse.Modules.Users.Infrastructure.Queries;

internal sealed class GetStudentDetailsHandler : IQueryHandler<GetStudentDetails, StudentDetailsDto>
{
    private readonly IQueryStudentRepository _queryStudentRepository;

    public GetStudentDetailsHandler(IQueryStudentRepository queryStudentRepository)
    {
        _queryStudentRepository = queryStudentRepository;
    }

    public async Task<Result<StudentDetailsDto>> HandleAsync(GetStudentDetails query, CancellationToken cancellationToken = default)
    {
        var student = await _queryStudentRepository.GetDetailsAsync(query.StudentId, cancellationToken);
        if (student is null) return Result.NotFound<StudentDetailsDto>(nameof(Student), query.StudentId);

        var mapped = student.ToStudentDetailsDto();

        return Result.Success(mapped);
    }
}
