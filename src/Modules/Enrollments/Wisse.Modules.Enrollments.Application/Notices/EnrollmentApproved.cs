using Wisse.Common.Communication.External;
using Wisse.Modules.Enrollments.Application.DTO.Queries.Enrollment;

namespace Wisse.Modules.Enrollments.Application.Notices;

public record EnrollmentApproved(EnrollmentDetailsDto Enrollment) : INotice;