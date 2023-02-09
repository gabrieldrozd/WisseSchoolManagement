using MassTransit;
using Microsoft.Extensions.Logging;
using Wisse.Contracts.Enrollments.Approved;
using Wisse.Modules.Users.Application.Features.Students.Commands;
using Wisse.Modules.Users.Application.Mappings;
using Wisse.Shared.Abstractions.Communication.Internal.Commands;

namespace Wisse.Modules.Users.Application.Consumers;

public sealed class EnrollmentApprovedConsumer : IConsumer<EnrollmentApproved>
{
    private readonly ILogger<EnrollmentApprovedConsumer> _logger;
    private readonly ICommandDispatcher _commandDispatcher;

    public EnrollmentApprovedConsumer(
        ILogger<EnrollmentApprovedConsumer> logger,
        ICommandDispatcher commandDispatcher)
    {
        _logger = logger;
        _commandDispatcher = commandDispatcher;
    }

    public async Task Consume(ConsumeContext<EnrollmentApproved> context)
    {
        var studentId = Guid.NewGuid();
        var userId = Guid.NewGuid();

        var registrationResult = await _commandDispatcher.SendAsync(new RegisterStudent(
            userId,
            studentId,
            context.Message.Enrollment.ToDefinition(),
            context.Message.Enrollment.Applicant.ToDefinition(),
            context.Message.Enrollment.Contact.ToDefinition()));
        if (!registrationResult.IsSuccess)
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