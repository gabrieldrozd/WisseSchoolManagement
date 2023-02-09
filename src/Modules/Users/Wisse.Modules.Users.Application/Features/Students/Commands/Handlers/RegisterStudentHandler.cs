using Wisse.Base.Results;
using Wisse.Base.Results.Core;
using Wisse.Modules.Users.Domain.Entities;
using Wisse.Modules.Users.Domain.Entities.Users;
using Wisse.Modules.Users.Domain.Interfaces.Repositories;
using Wisse.Modules.Users.Domain.Interfaces.Services;
using Wisse.Modules.Users.Domain.Interfaces.UnitOfWork;
using Wisse.Shared.Abstractions.Communication.Internal.Commands;

namespace Wisse.Modules.Users.Application.Features.Students.Commands.Handlers;

internal class RegisterStudentHandler : ICommandHandler<RegisterStudent>
{
    private readonly IQueryUserRepository _queryUserRepository;
    private readonly ICommandUserRepository _commandUserRepository;
    private readonly ICommandStudentRepository _commandStudentRepository;
    private readonly IIdentityService _identityService;
    private readonly IUsersUnitOfWork _unitOfWork;

    public RegisterStudentHandler(
        IQueryUserRepository queryUserRepository,
        ICommandUserRepository commandUserRepository,
        ICommandStudentRepository commandStudentRepository,
        IIdentityService identityService,
        IUsersUnitOfWork unitOfWork)
    {
        _queryUserRepository = queryUserRepository;
        _commandUserRepository = commandUserRepository;
        _commandStudentRepository = commandStudentRepository;
        _identityService = identityService;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> HandleAsync(RegisterStudent command, CancellationToken cancellationToken = default)
    {
        if (await _queryUserRepository.IsEmailInUseAsync(command.UserDefinition.Email))
        {
            return Result.Failure(Failure.EmailInUse);
        }

        var studentUser = StudentUser.Create(command.UserId, command.StudentId, command.UserDefinition);
        var passwordHash = _identityService.GenerateHashedPassword(studentUser);
        studentUser.SetPasswordHash(passwordHash);

        var student = Student.Create(command.StudentId, command.StudentDefinition);
        var contact = Contact.Create(command.ContactDefinition);
        student.SetContact(contact);

        _commandUserRepository.Insert(studentUser);
        _commandStudentRepository.Insert(student);

        var result = await _unitOfWork.CommitAsync(cancellationToken);

        return result.IsSuccess
            ? Result.Success()
            : Result.Failure(Failure.Database);
    }
}