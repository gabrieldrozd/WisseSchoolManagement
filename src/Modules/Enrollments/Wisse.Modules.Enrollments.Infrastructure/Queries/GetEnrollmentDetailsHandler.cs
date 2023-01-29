using Wisse.Common.Results;
using Wisse.Common.Results.Errors;
using Wisse.Modules.Enrollments.Application.DTO.Enrollment;
using Wisse.Modules.Enrollments.Application.Features.Queries;
using Wisse.Modules.Enrollments.Application.Mappings;
using Wisse.Modules.Enrollments.Domain.Repositories;
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
        var enrollment = await _repository.GetDetailsAsync(query.EnrollmentId);
        if (enrollment is null)
        {
            return Result.Failure(ErrorType.EnrollmentNotFound);
        }

        var mapped = enrollment.ToEnrollmentDetailsDto();

        return Result.Success(mapped);
    }
}