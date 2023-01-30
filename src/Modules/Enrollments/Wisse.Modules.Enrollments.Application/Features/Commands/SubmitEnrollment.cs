using Wisse.Common.Utilities.Messaging.Mediator;
using Wisse.Modules.Enrollments.Application.DTO.Commands.Enrollment;

namespace Wisse.Modules.Enrollments.Application.Features.Commands;

public record SubmitEnrollment(EnrollmentPostDto Enrollment) : ICommand;