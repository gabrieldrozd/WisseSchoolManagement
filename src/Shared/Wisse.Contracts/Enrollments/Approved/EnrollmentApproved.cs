using Wisse.Common.Communication;
using Wisse.Contracts.Enrollments.Approved.Contracts;

namespace Wisse.Contracts.Enrollments.Approved;

public record EnrollmentApproved(EnrollmentDetailsContract Enrollment) : IMessage;