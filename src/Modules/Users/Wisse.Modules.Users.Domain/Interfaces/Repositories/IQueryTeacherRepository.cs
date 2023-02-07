using Wisse.Common.Models.Pagination;
using Wisse.Modules.Users.Domain.Entities;
using Wisse.Shared.Abstractions.Database.Repositories;

namespace Wisse.Modules.Users.Domain.Interfaces.Repositories;

public interface IQueryTeacherRepository : IQueryBaseRepository<Teacher>
{
    // TODO: Teacher should contain User

    // Task<Teacher> GetAsync(Guid teacherId, CancellationToken cancellationToken = default);
    Task<Teacher> GetDetailsAsync(Guid teacherId, CancellationToken cancellationToken = default);
    Task<PaginatedList<Teacher>> BrowseAsync(Pagination pagination, CancellationToken cancellationToken = default);
}