using Wisse.Common.Models.Pagination;
using Wisse.Common.Utilities.Configuration;
using Wisse.Modules.Enrollments.Domain.Entities;

namespace Wisse.Modules.Enrollments.Domain.Interfaces.Repositories;

public interface IQueryEnrollmentRepository : IRepository
{
    Task<Enrollment> GetAsync(Guid enrollmentId, CancellationToken cancellationToken = default);
    Task<Enrollment> GetDetailsAsync(Guid enrollmentId, CancellationToken cancellationToken = default);
    Task<PaginatedList<Enrollment>> BrowseAsync(Pagination pagination, CancellationToken cancellationToken = default);

}