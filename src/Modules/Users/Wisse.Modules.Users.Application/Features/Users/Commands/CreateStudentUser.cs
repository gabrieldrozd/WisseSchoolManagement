using Wisse.Common.Communication.Internal;
using Wisse.Modules.Users.Domain.Definitions.Users;
using Wisse.Modules.Users.Domain.Entities;

namespace Wisse.Modules.Users.Application.Features.Users.Commands;

public record CreateStudentUser(
    Guid UserId,
    Student Student,
    StudentUserDefinition StudentUserDefinition
) : ICommand;