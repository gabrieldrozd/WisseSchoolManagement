using Wisse.Common.Communication.Internal;
using Wisse.Modules.Users.Domain.Definitions;

namespace Wisse.Modules.Users.Application.Features.Students.Commands;

public record RegisterStudent(
    Guid UserId,
    Guid StudentId,
    UserDefinition UserDefinition,
    StudentDefinition StudentDefinition,
    ContactDefinition ContactDefinition
) : ICommand;