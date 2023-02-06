using Wisse.Base.Results;
using Wisse.Modules.Enrollments.Application.DTO.Queries.Enrollment;
using Wisse.Modules.Enrollments.Application.Features.Queries;
using Wisse.Modules.Enrollments.Application.Mappings.DTO;
using Wisse.Modules.Enrollments.Domain.Entities;
using Wisse.Modules.Enrollments.Domain.Interfaces.Repositories;
using Wisse.Shared.Abstractions.Communication.Internal.Queries;

namespace Wisse.Modules.Enrollments.Infrastructure.Queries;

internal sealed class GetEnrollmentDetailsHandler : IQueryHandler<GetEnrollmentDetails, EnrollmentDetailsDto>
{
    private readonly IQueryEnrollmentRepository _queryEnrollmentRepository;

    public GetEnrollmentDetailsHandler(IQueryEnrollmentRepository queryEnrollmentRepository)
    {
        _queryEnrollmentRepository = queryEnrollmentRepository;
    }

    public async Task<Result<EnrollmentDetailsDto>> HandleAsync(GetEnrollmentDetails query, CancellationToken cancellationToken = default)
    {
        var enrollment = await _queryEnrollmentRepository.GetDetailsAsync(query.EnrollmentId, cancellationToken);
        if (enrollment is null) return Result.NotFound<EnrollmentDetailsDto>(nameof(Enrollment), query.EnrollmentId);

        var mapped = enrollment.ToEnrollmentDetailsDto();

        return Result.Success(mapped);
    }
}