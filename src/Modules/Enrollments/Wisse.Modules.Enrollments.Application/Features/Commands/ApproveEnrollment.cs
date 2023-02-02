using Wisse.Common.Communication.Internal;

namespace Wisse.Modules.Enrollments.Application.Features.Commands;

public record ApproveEnrollment(Guid EnrollmentId) : ICommand;