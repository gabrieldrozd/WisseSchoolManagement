using Microsoft.AspNetCore.Identity;
using Wisse.Base.Results;
using Wisse.Common.Domain.Users;
using Wisse.Modules.Users.Domain.Entities.Users;
using Wisse.Modules.Users.Domain.Entities.Users.Base;
using Wisse.Shared.Abstractions.Communication.Internal.Commands;

namespace Wisse.Modules.Users.Application.Features.Users.Commands.Handlers;

internal class CreateStudentUserHandler : ICommandHandler<CreateStudentUser>
{
    private readonly UserManager<User> _userManager;

    public CreateStudentUserHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Result> HandleAsync(CreateStudentUser command, CancellationToken cancellationToken = default)
    {
        var studentUser = StudentUser.Create(command.UserId, command.StudentUserDefinition);
        studentUser.SetStudent(command.Student);

        var tempPassword = $"Wisse{Guid.NewGuid().ToString()[..4]}@";
        await _userManager.CreateAsync(studentUser, tempPassword);
        await _userManager.AddToRoleAsync(studentUser, Roles.StudentRole.Name);

        return Result.Success();
    }
}
