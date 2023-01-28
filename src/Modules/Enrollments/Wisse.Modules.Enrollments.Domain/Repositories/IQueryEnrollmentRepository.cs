using Wisse.Common.Models;
using Wisse.Common.Utilities.Configuration;
using Wisse.Modules.Enrollments.Domain.Entities;

namespace Wisse.Modules.Enrollments.Domain.Repositories;

public interface IQueryEnrollmentRepository : IRepository
{
    Task<Enrollment> GetDetailsAsync(Guid enrollmentId);
    Task<IReadOnlyList<Enrollment>> BrowseAsync(Pagination pagination);
}