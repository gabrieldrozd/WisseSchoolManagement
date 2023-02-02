using Wisse.Common.Communication.External;
using Wisse.Modules.Users.Application.Notices.EnrollmentApproved.DTO;

namespace Wisse.Modules.Users.Application.Notices.EnrollmentApproved;

public record EnrollmentApproved(EnrollmentDetailsDto Enrollment) : INotice;