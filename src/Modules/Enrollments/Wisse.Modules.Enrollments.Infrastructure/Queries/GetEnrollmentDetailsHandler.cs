using Wisse.Base.Results;
using Wisse.Modules.Enrollments.Application.DTO.Queries.Enrollment;
using Wisse.Modules.Enrollments.Application.Features.Queries;
using Wisse.Modules.Enrollments.Application.Mappings;
using Wisse.Modules.Enrollments.Domain.Entities;
using Wisse.Modules.Enrollments.Domain.Interfaces.Repositories;
using Wisse.Shared.Abstractions.Communication.Internal.Queries;

namespace Wisse.Modules.Enrollments.Infrastructure.Queries;

internal sealed class GetEnrollmentDetailsHandler : IQueryHandler<GetEnrollmentDetails, EnrollmentDetailsDto>
{
    private readonly IQueryEnrollmentRepository _repository;

    public GetEnrollmentDetailsHandler(IQueryEnrollmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<EnrollmentDetailsDto>> HandleAsync(GetEnrollmentDetails query, CancellationToken cancellationToken = default)
    {
        var enrollment = await _repository.GetDetailsAsync(query.EnrollmentId, cancellationToken);
        if (enrollment is null) return Result.NotFound<EnrollmentDetailsDto>(nameof(Enrollment), query.EnrollmentId);

        var mapped = enrollment.ToEnrollmentDetailsDto();

        return Result.Success(mapped);
    }
}