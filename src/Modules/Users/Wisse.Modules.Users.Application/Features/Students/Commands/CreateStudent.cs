using Wisse.Common.Communication.Internal;
using Wisse.Modules.Users.Domain.Definitions;

namespace Wisse.Modules.Users.Application.Features.Students.Commands;

public record CreateStudent(
    Guid StudentId,
    Guid UserId,
    StudentDefinition StudentDefinition,
    ContactDefinition ContactDefinition
) : ICommand;