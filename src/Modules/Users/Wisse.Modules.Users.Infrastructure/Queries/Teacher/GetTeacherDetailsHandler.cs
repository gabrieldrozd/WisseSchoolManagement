using Wisse.Base.Results;
using Wisse.Modules.Users.Application.DTO.Queries.Teacher;
using Wisse.Modules.Users.Application.Features.Teachers.Queries;
using Wisse.Modules.Users.Application.Mappings;
using Wisse.Modules.Users.Domain.Interfaces.Repositories;
using Wisse.Shared.Abstractions.Communication.Internal.Queries;

namespace Wisse.Modules.Users.Infrastructure.Queries.Teacher;

internal sealed class GetTeacherDetailsHandler : IQueryHandler<GetTeacherDetails, TeacherDetailsDto>
{
    private readonly IQueryTeacherRepository _queryTeacherRepository;

    public GetTeacherDetailsHandler(IQueryTeacherRepository queryTeacherRepository)
    {
        _queryTeacherRepository = queryTeacherRepository;
    }

    public async Task<Result<TeacherDetailsDto>> HandleAsync(GetTeacherDetails query, CancellationToken cancellationToken = default)
    {
        var teacher = await _queryTeacherRepository.GetDetailsAsync(query.TeacherId, cancellationToken);
        if (teacher is null) return Result.NotFound<TeacherDetailsDto>(nameof(Domain.Entities.Teacher), query.TeacherId);

        var mapped = teacher.ToTeacherDetailsDto();

        return Result.Success(mapped);
    }
}
