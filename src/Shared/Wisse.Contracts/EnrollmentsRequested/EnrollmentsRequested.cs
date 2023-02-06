using Wisse.Common.Communication;
using Wisse.Contracts.EnrollmentsRequested.Contracts;

namespace Wisse.Contracts.EnrollmentsRequested;

public record EnrollmentsRequested(EnrollmentContract Enrollment) : IMessage;