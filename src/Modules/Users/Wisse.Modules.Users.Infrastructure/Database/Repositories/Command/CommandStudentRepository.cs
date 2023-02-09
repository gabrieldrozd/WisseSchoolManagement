using Wisse.Modules.Users.Domain.Interfaces.Repositories;
using Wisse.Shared.Infrastructure.Database.Repositories;

namespace Wisse.Modules.Users.Infrastructure.Database.Repositories.Command;

internal class CommandStudentRepository
    : CommandBaseRepository<Domain.Entities.Student, UsersDbContext>,
      ICommandStudentRepository
{
    public CommandStudentRepository(UsersDbContext context)
        : base(context)
    {
    }
}