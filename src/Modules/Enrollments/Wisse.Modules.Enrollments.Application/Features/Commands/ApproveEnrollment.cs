using Wisse.Common.Messaging.Mediator;

namespace Wisse.Modules.Enrollments.Application.Features.Commands;

public record ApproveEnrollment(Guid EnrollmentId) : ICommand;