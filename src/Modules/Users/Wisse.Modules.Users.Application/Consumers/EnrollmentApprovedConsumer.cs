using MassTransit;
using Microsoft.Extensions.Logging;
using Wisse.Contracts.Enrollments.Approved;
using Wisse.Modules.Users.Application.Features.Students.Commands;
using Wisse.Modules.Users.Application.Features.Users.Commands;
using Wisse.Modules.Users.Application.Mappings;
using Wisse.Modules.Users.Application.Mappings.Users;
using Wisse.Modules.Users.Domain.Entities;
using Wisse.Modules.Users.Domain.Interfaces.UnitOfWork;
using Wisse.Shared.Abstractions.Communication.Internal.Commands;

namespace Wisse.Modules.Users.Application.Consumers;

public sealed class EnrollmentApprovedConsumer : IConsumer<EnrollmentApproved>
{
    private readonly ILogger<EnrollmentApprovedConsumer> _logger;
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IUsersUnitOfWork _unitOfWork;

    public EnrollmentApprovedConsumer(
        ILogger<EnrollmentApprovedConsumer> logger,
        ICommandDispatcher commandDispatcher,
        IUsersUnitOfWork unitOfWork)
    {
        _logger = logger;
        _commandDispatcher = commandDispatcher;
        _unitOfWork = unitOfWork;
    }

    public async Task Consume(ConsumeContext<EnrollmentApproved> context)
    {
        var studentId = Guid.NewGuid();
        var userId = Guid.NewGuid();

        var studentResult = await _commandDispatcher.SendAsync<CreateStudent, Student>(new CreateStudent(
            studentId,
            userId,
            context.Message.Enrollment.Applicant.ToDefinition(),
            context.Message.Enrollment.Contact.ToDefinition()));
        if (!studentResult.IsSuccess)
        {
            _logger.LogError("Failed to create Student from Enrollment with ID: '{ExternalId:D}'",
                context.Message.Enrollment.ExternalId);
            return;
        }

        var userResult = await _commandDispatcher.SendAsync(new CreateStudentUser(
            userId,
            studentResult.Value,
            context.Message.Enrollment.ToDefinition()));
        if (!userResult.IsSuccess)
        {
            _logger.LogError("Failed to create User from Enrollment with ID: '{ExternalId:D}'",
                context.Message.Enrollment.ExternalId);
            return;
        }

        var result = await _unitOfWork.CommitAsync();
        if (!result.IsSuccess)
        {
            _logger.LogError("Failed to create Student with User from Enrollment with ID: '{ExternalId:D}'",
                context.Message.Enrollment.ExternalId);
            return;
        }

        _logger.LogInformation("Created Student with ID: '{StudentId:D}' from Enrollment with ID: '{ExternalId:D}'",
            studentId, context.Message.Enrollment.ExternalId);
        // TODO: Publish new message for sending EMAIL with account details to newly created studentUser
        // CreateStudentUserHandler should probably return student details or should directly send such email
    }
}