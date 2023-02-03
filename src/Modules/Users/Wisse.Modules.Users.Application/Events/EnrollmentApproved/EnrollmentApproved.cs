using Wisse.Common.Communication.External;
using Wisse.Modules.Users.Application.Events.EnrollmentApproved.DTO;

namespace Wisse.Modules.Users.Application.Events.EnrollmentApproved;

public record EnrollmentApproved(EnrollmentDetailsDto Enrollment) : IEvent;