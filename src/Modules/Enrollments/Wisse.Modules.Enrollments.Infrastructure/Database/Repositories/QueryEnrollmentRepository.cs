using Microsoft.EntityFrameworkCore;
using Wisse.Common.Extensions;
using Wisse.Common.Models;
using Wisse.Modules.Enrollments.Domain.Entities;
using Wisse.Modules.Enrollments.Domain.Repositories;

namespace Wisse.Modules.Enrollments.Infrastructure.Database.Repositories;

internal class QueryEnrollmentRepository : IQueryEnrollmentRepository
{
    private readonly DbSet<Enrollment> _enrollments;

    public QueryEnrollmentRepository(EnrollmentsDbContext context)
    {
        _enrollments = context.Enrollments;
    }

    public async Task<Enrollment> GetDetailsAsync(Guid enrollmentId)
    {
        var enrollment = await _enrollments
            .Where(x => x.Id.Equals(enrollmentId))
            .AsNoTracking()
            .SingleOrDefaultAsync();

        return enrollment;
    }

    public async Task<IReadOnlyList<Enrollment>> BrowseAsync(Pagination pagination)
    {
        var enrollments = await _enrollments
            .AddPagination(pagination)
            .AddIncludes(
                x => x.Applicant,
                x => x.Contact)
            .AsNoTracking()
            .ToListAsync();

        return enrollments;
    }
}
