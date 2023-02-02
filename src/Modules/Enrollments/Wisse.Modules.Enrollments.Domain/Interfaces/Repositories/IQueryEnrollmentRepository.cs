using Wisse.Common.Models.Pagination;
using Wisse.Modules.Enrollments.Domain.Entities;
using Wisse.Shared.Abstractions.Database.Repositories;

namespace Wisse.Modules.Enrollments.Domain.Interfaces.Repositories;

public interface IQueryEnrollmentRepository : IQueryBaseRepository<Enrollment>
{
    Task<Enrollment> GetAsync(Guid enrollmentId, CancellationToken cancellationToken = default);
    Task<Enrollment> GetDetailsAsync(Guid enrollmentId, CancellationToken cancellationToken = default);
    Task<PaginatedList<Enrollment>> BrowseAsync(Pagination pagination, CancellationToken cancellationToken = default);

}