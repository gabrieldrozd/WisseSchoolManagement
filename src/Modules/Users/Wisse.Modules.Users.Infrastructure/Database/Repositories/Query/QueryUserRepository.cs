using Microsoft.EntityFrameworkCore;
using Wisse.Common.Domain.ValueObjects;
using Wisse.Modules.Users.Domain.Entities.Users;
using Wisse.Modules.Users.Domain.Interfaces.Repositories;
using Wisse.Shared.Infrastructure.Database.Repositories;

namespace Wisse.Modules.Users.Infrastructure.Database.Repositories.Query;

internal class QueryUserRepository : QueryBaseRepository<User, UsersDbContext>, IQueryUserRepository
{
    private readonly DbSet<User> _users;

    public QueryUserRepository(UsersDbContext context) : base(context)
    {
        _users = context.Users;
    }

    public Task<bool> IsEmailInUseAsync(string email)
        => _users.AnyAsync(u => u.Email.Equals(email));

    public Task<User> GetByEmailAsync(string email)
        => _users.Where(x => x.Email == new Email(email)).AsNoTracking().SingleOrDefaultAsync();
}
