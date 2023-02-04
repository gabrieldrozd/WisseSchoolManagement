using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Wisse.Modules.Users.Application.Mappings;
using Wisse.Modules.Users.Application.Mappings.Users;
using Wisse.Modules.Users.Domain.Entities;
using Wisse.Modules.Users.Domain.Entities.Users;
using Wisse.Modules.Users.Domain.Entities.Users.Base;
using Wisse.Modules.Users.Domain.Interfaces.Repositories;
using Wisse.Modules.Users.Domain.Interfaces.UnitOfWork;
using Wisse.Shared.Abstractions.Communication.External.Events;

namespace Wisse.Modules.Users.Application.Events.EnrollmentApproved;

internal sealed class EnrollmentApprovedHandler : IEventHandler<EnrollmentApproved>
{
    private readonly ILogger<EnrollmentApprovedHandler> _logger;
    private readonly ICommandStudentRepository _commandStudentRepository;
    private readonly UserManager<User> _userManager;
    private readonly IUsersUnitOfWork _unitOfWork;

    public EnrollmentApprovedHandler(
        ILogger<EnrollmentApprovedHandler> logger,
        ICommandStudentRepository commandStudentRepository,
        UserManager<User> userManager,
        IUsersUnitOfWork unitOfWork)
    {
        _logger = logger;
        _commandStudentRepository = commandStudentRepository;
        _userManager = userManager;
        _unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(EnrollmentApproved @event)
    {
        var studentId = Guid.NewGuid();
        var userId = Guid.NewGuid();

        var student = Student.Create(studentId, userId, @event.Enrollment.Applicant.ToDefinition());
        var contact = Contact.Create(@event.Enrollment.Contact.ToDefinition());
        student.SetContact(contact);

        _commandStudentRepository.Insert(student);

        var tempPassword = $"Wisse{Guid.NewGuid().ToString()[..4]}@";
        var studentUser = StudentUser.Create(userId, @event.Enrollment.ToDefinition());
        studentUser.SetStudent(student);
        var userResult = await _userManager.CreateAsync(studentUser, tempPassword);
        if (!userResult.Succeeded)
        {
            _logger.LogError("Failed to create User from Enrollment with ID: '{ExternalId:D}'", @event.Enrollment.ExternalId);
            return;
        }

        var studentResult = await _unitOfWork.CommitAsync();
        if (studentResult.IsFailure)
        {
            _logger.LogError("Failed to create Student from Enrollment with ID: '{ExternalId:D}'", @event.Enrollment.ExternalId);
            return;
        }

        _logger.LogInformation("Created Student with ID: '{StudentId:D}' from Enrollment with ID: '{ExternalId:D}'",
            studentId, @event.Enrollment.ExternalId);
    }
}
