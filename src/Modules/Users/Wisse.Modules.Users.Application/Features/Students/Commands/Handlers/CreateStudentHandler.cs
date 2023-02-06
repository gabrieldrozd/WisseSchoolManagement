using Wisse.Base.Results;
using Wisse.Modules.Users.Domain.Entities;
using Wisse.Modules.Users.Domain.Interfaces.Repositories;
using Wisse.Shared.Abstractions.Communication.Internal.Commands;

namespace Wisse.Modules.Users.Application.Features.Students.Commands.Handlers;

internal class CreateStudentHandler : ICommandHandler<CreateStudent, Student>
{
    private readonly ICommandStudentRepository _commandStudentRepository;

    public CreateStudentHandler(ICommandStudentRepository commandStudentRepository)
    {
        _commandStudentRepository = commandStudentRepository;
    }

    public Task<Result<Student>> HandleAsync(CreateStudent command, CancellationToken cancellationToken = default)
    {
        var student = Student.Create(command.StudentId, command.UserId, command.StudentDefinition);
        var contact = Contact.Create(command.ContactDefinition);
        student.SetContact(contact);

        _commandStudentRepository.Insert(student);
        return Task.FromResult(Result.Success(student));
    }
}
