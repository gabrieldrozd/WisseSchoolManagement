using Wisse.Common.Communication.Internal;

namespace Wisse.Modules.Enrollments.Application.Features.Commands;

public record RejectEnrollment(Guid EnrollmentId) : ICommand;