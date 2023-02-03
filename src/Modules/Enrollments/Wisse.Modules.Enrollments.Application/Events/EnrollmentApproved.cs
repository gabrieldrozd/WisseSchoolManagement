using Wisse.Common.Communication.External;
using Wisse.Modules.Enrollments.Application.DTO.Queries.Enrollment;

namespace Wisse.Modules.Enrollments.Application.Events;

public record EnrollmentApproved(EnrollmentDetailsDto Enrollment) : IEvent;