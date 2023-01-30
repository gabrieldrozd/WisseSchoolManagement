using Wisse.Common.Results;
using Wisse.Common.Results.Errors;
using Wisse.Modules.Enrollments.Application.DTO.Queries.Enrollment;
using Wisse.Modules.Enrollments.Application.Features.Queries;
using Wisse.Modules.Enrollments.Application.Mappings;
using Wisse.Modules.Enrollments.Domain.Errors;
using Wisse.Modules.Enrollments.Domain.Interfaces.Repositories;
using Wisse.Shared.Abstractions.Mediator.Queries;

namespace Wisse.Modules.Enrollments.Infrastructure.Queries;

internal sealed class GetEnrollmentDetailsHandler : IQueryHandler<GetEnrollmentDetails, EnrollmentDetailsDto>
{
    private readonly IQueryEnrollmentRepository _repository;

    public GetEnrollmentDetailsHandler(IQueryEnrollmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> HandleAsync(GetEnrollmentDetails query, CancellationToken cancellationToken = default)
    {
        var enrollment = await _repository.GetDetailsAsync(query.EnrollmentId, cancellationToken);
        if (enrollment is null)
        {
            // return Result.Failure(EnrollmentErrorCode.NotFound);
            return Result.Failure(EnrollmentErrorCode.NotFound.NotFoundWithId(query.EnrollmentId.ToString()));
        }

        var mapped = enrollment.ToEnrollmentDetailsDto();

        return Result.Success(mapped);
    }
}