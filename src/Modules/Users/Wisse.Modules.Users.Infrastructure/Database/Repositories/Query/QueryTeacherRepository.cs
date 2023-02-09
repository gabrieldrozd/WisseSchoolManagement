using Microsoft.EntityFrameworkCore;
using Wisse.Common.Extensions;
using Wisse.Common.Models.Pagination;
using Wisse.Modules.Users.Domain.Entities;
using Wisse.Modules.Users.Domain.Interfaces.Repositories;
using Wisse.Shared.Infrastructure.Database.Repositories;

namespace Wisse.Modules.Users.Infrastructure.Database.Repositories.Query;

internal class QueryTeacherRepository : QueryBaseRepository<Teacher, UsersDbContext>, IQueryTeacherRepository
{
    private readonly DbSet<Teacher> _teachers;

    public QueryTeacherRepository(UsersDbContext context)
        : base(context)
    {
        _teachers = context.Teachers;
    }

    public async Task<Teacher> GetAsync(Guid teacherId, CancellationToken cancellationToken = default)
    {
        var teacher = await _teachers
            .Where(x => x.ExternalId.Equals(teacherId))
            .SingleOrDefaultAsync(cancellationToken);

        return teacher;
    }

    public async Task<Teacher> GetDetailsAsync(Guid teacherId, CancellationToken cancellationToken = default)
    {
        var teacher = await _teachers
            .Where(x => x.ExternalId.Equals(teacherId))
            .AddIncludes(x => x.User)
            .AsNoTracking()
            .SingleOrDefaultAsync(cancellationToken);

        return teacher;
    }

    public async Task<PaginatedList<Teacher>> BrowseAsync(Pagination pagination, CancellationToken cancellationToken = default)
    {
        var teachers = await _teachers
            .AddPagination(pagination)
            .AddIncludes(x => x.User)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var totalItems = await TotalCountAsync();

        return PaginatedList<Teacher>.Create(pagination, teachers, totalItems);
    }
}