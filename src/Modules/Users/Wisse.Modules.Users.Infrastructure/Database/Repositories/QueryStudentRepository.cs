using Microsoft.EntityFrameworkCore;
using Wisse.Common.Extensions;
using Wisse.Common.Models.Pagination;
using Wisse.Modules.Users.Domain.Entities;
using Wisse.Modules.Users.Domain.Interfaces.Repositories;
using Wisse.Shared.Infrastructure.Database.Repositories;

namespace Wisse.Modules.Users.Infrastructure.Database.Repositories;

internal class QueryStudentRepository : QueryBaseRepository<Student, UsersDbContext>, IQueryStudentRepository
{
    private readonly DbSet<Student> _students;

    public QueryStudentRepository(UsersDbContext context)
        : base(context)
    {
        _students = context.Students;
    }

    public async Task<Student> GetAsync(Guid studentId, CancellationToken cancellationToken = default)
    {
        var enrollment = await _students
            .Where(x => x.ExternalId.Equals(studentId))
            .SingleOrDefaultAsync(cancellationToken);

        return enrollment;
    }

    public async Task<Student> GetDetailsAsync(Guid studentId, CancellationToken cancellationToken = default)
    {
        var enrollment = await _students
            .Where(x => x.ExternalId.Equals(studentId))
            .AsNoTracking()
            .SingleOrDefaultAsync(cancellationToken);

        return enrollment;
    }

    public async Task<PaginatedList<Student>> BrowseAsync(Pagination pagination, CancellationToken cancellationToken = default)
    {
        var students = await _students
            .AddPagination(pagination)
            .AddIncludes(
                x => x.Contact)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var totalItems = await TotalCountAsync();

        return PaginatedList<Student>.Create(pagination, students, totalItems);
    }
}