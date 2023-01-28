using Wisse.Common.Results;
using Wisse.Modules.Enrollments.Application.DTO.Enrollment;
using Wisse.Modules.Enrollments.Application.Features.Queries;
using Wisse.Modules.Enrollments.Application.Mappings;
using Wisse.Modules.Enrollments.Domain.Repositories;
using Wisse.Shared.Abstractions.Mediator.Query;

namespace Wisse.Modules.Enrollments.Infrastructure.Queries;

internal sealed class GetEnrollmentDetailsHandler : IQueryHandler<GetEnrollmentDetails, EnrollmentDetailsDto>
{
    private readonly IQueryEnrollmentRepository _repository;

    public GetEnrollmentDetailsHandler(IQueryEnrollmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<DataResult<EnrollmentDetailsDto>> Handle(GetEnrollmentDetails request, CancellationToken cancellationToken)
    {
        var enrollment = await _repository.GetDetailsAsync(request.EnrollmentId);
        var mapped = enrollment.ToEnrollmentDetailsDto();

        return Result.Success(mapped);
    }
}
