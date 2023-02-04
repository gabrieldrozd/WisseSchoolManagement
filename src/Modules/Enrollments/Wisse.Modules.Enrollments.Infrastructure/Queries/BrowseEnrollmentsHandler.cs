using Wisse.Base.Results;
using Wisse.Common.Extensions;
using Wisse.Common.Models.Pagination;
using Wisse.Modules.Enrollments.Application.DTO.Queries.Enrollment;
using Wisse.Modules.Enrollments.Application.Features.Queries;
using Wisse.Modules.Enrollments.Application.Mappings;
using Wisse.Modules.Enrollments.Domain.Interfaces.Repositories;
using Wisse.Shared.Abstractions.Communication.Internal.Queries;

namespace Wisse.Modules.Enrollments.Infrastructure.Queries;

internal sealed class BrowseEnrollmentsHandler : IQueryHandler<BrowseEnrollments, PaginatedList<EnrollmentDto>>
{
    private readonly IQueryEnrollmentRepository _queryEnrollmentRepository;

    public BrowseEnrollmentsHandler(IQueryEnrollmentRepository queryEnrollmentRepository)
    {
        _queryEnrollmentRepository = queryEnrollmentRepository;
    }

    public async Task<Result<PaginatedList<EnrollmentDto>>> HandleAsync(
        BrowseEnrollments query, CancellationToken cancellationToken = default)
    {
        var enrollments = await _queryEnrollmentRepository.BrowseAsync(query.Pagination, cancellationToken);
        var mapped = enrollments.MapTo(EnrollmentMappings.ToEnrollmentDto);

        return Result.Success(mapped);
    }
}