using Wisse.Modules.Users.Domain.Interfaces.UnitOfWork;
using Wisse.Shared.Infrastructure.Database.UnitOfWork;

namespace Wisse.Modules.Users.Infrastructure.Database.UnitOfWork;

internal class UsersUnitOfWork : BaseUnitOfWork<UsersDbContext>, IUsersUnitOfWork
{
    public UsersUnitOfWork(UsersDbContext context)
        : base(context)
    {
    }
}