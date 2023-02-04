using Wisse.Modules.Users.Domain.Entities;
using Wisse.Shared.Abstractions.Database.Repositories;

namespace Wisse.Modules.Users.Domain.Interfaces.Repositories;

public interface IQueryStudentRepository : IQueryBaseRepository<Student>
{
    // TODO: Student should contain User

    // Task<Student> GetAsync(Guid studentId, CancellationToken cancellationToken = default);
    // Task<Student> GetDetailsAsync(Guid studentId, CancellationToken cancellationToken = default);
    // Task<PaginatedList<Student>> BrowseAsync(Pagination pagination, CancellationToken cancellationToken = default);
}