using Wisse.Modules.Users.Domain.Interfaces.Repositories;
using Wisse.Shared.Infrastructure.Database.Repositories;

namespace Wisse.Modules.Users.Infrastructure.Database.Repositories.Command;

internal class CommandTeacherRepository
    : CommandBaseRepository<Domain.Entities.Teacher, UsersDbContext>,
      ICommandTeacherRepository
{
    public CommandTeacherRepository(UsersDbContext context)
        : base(context)
    {
    }
}