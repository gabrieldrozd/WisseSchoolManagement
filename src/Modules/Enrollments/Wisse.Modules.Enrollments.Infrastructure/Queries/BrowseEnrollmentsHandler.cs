using Wisse.Common.Extensions;
using Wisse.Common.Models;
using Wisse.Common.Results;
using Wisse.Modules.Enrollments.Application.DTO.Queries.Enrollment;
using Wisse.Modules.Enrollments.Application.Features.Queries;
using Wisse.Modules.Enrollments.Application.Mappings;
using Wisse.Modules.Enrollments.Domain.Interfaces.Repositories;
using Wisse.Shared.Abstractions.Mediator.Queries;

namespace Wisse.Modules.Enrollments.Infrastructure.Queries;

internal sealed class BrowseEnrollmentsHandler : IQueryHandler<BrowseEnrollments, PaginatedList<EnrollmentDto>>
{
    private readonly IQueryEnrollmentRepository _repository;

    public BrowseEnrollmentsHandler(IQueryEnrollmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> HandleAsync(BrowseEnrollments query, CancellationToken cancellationToken = default)
    {
        var enrollments = await _repository.BrowseAsync(query.Pagination, cancellationToken);
        var mapped = enrollments.MapTo(EnrollmentMappings.ToEnrollmentDto);

        return Result.Success(mapped);
    }
}