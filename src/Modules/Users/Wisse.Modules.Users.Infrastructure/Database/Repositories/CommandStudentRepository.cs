using Wisse.Modules.Users.Domain.Entities;
using Wisse.Modules.Users.Domain.Interfaces.Repositories;
using Wisse.Shared.Infrastructure.Database.Repositories;

namespace Wisse.Modules.Users.Infrastructure.Database.Repositories;

internal class CommandStudentRepository
    : CommandBaseRepository<Student, UsersDbContext>,
      ICommandStudentRepository
{
    public CommandStudentRepository(UsersDbContext context)
        : base(context)
    {
    }
}