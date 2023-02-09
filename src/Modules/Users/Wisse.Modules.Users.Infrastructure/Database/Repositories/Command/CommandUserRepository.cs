using Wisse.Modules.Users.Domain.Entities.Users;
using Wisse.Modules.Users.Domain.Interfaces.Repositories;
using Wisse.Shared.Infrastructure.Database.Repositories;

namespace Wisse.Modules.Users.Infrastructure.Database.Repositories.Command;

internal class CommandUserRepository
    : CommandBaseRepository<User, UsersDbContext>,
      ICommandUserRepository
{
    public CommandUserRepository(UsersDbContext context)
        : base(context)
    {
    }
}