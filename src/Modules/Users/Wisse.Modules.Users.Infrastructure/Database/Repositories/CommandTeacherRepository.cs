using Wisse.Modules.Users.Domain.Entities;
using Wisse.Modules.Users.Domain.Interfaces.Repositories;
using Wisse.Shared.Infrastructure.Database.Repositories;

namespace Wisse.Modules.Users.Infrastructure.Database.Repositories;

internal class CommandTeacherRepository
    : CommandBaseRepository<Teacher, UsersDbContext>,
      ICommandTeacherRepository
{
    public CommandTeacherRepository(UsersDbContext context)
        : base(context)
    {
    }
}