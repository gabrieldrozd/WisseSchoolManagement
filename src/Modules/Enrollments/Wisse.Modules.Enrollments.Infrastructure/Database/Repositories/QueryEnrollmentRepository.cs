using Microsoft.EntityFrameworkCore;
using Wisse.Common.Extensions;
using Wisse.Common.Models.Pagination;
using Wisse.Modules.Enrollments.Domain.Entities;
using Wisse.Modules.Enrollments.Domain.Interfaces.Repositories;

namespace Wisse.Modules.Enrollments.Infrastructure.Database.Repositories;

internal class QueryEnrollmentRepository : IQueryEnrollmentRepository
{
    private readonly DbSet<Enrollment> _enrollments;

    public QueryEnrollmentRepository(EnrollmentsDbContext context)
    {
        _enrollments = context.Enrollments;
    }

    public async Task<Enrollment> GetAsync(
        Guid enrollmentId, CancellationToken cancellationToken = default)
    {
        var enrollment = await _enrollments
            .Where(x => x.ExternalId.Equals(enrollmentId))
            .SingleOrDefaultAsync(cancellationToken);

        return enrollment;
    }

    public async Task<Enrollment> GetDetailsAsync(
        Guid enrollmentId, CancellationToken cancellationToken = default)
    {
        var enrollment = await _enrollments
            .Where(x => x.ExternalId.Equals(enrollmentId))
            .AsNoTracking()
            .SingleOrDefaultAsync(cancellationToken);

        return enrollment;
    }

    public async Task<PaginatedList<Enrollment>> BrowseAsync(
        Pagination pagination, CancellationToken cancellationToken = default)
    {
        var enrollments = await _enrollments
            .AddPagination(pagination)
            .AddIncludes(
                x => x.Applicant,
                x => x.Contact)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var totalItems = await _enrollments.CountAsync(cancellationToken);

        return PaginatedList<Enrollment>.Create(pagination, enrollments, totalItems);
    }
}
