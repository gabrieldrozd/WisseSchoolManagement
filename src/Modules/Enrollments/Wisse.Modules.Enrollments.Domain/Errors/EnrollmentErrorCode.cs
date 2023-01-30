using Wisse.Common.Results.Errors;

namespace Wisse.Modules.Enrollments.Domain.Errors;

public class EnrollmentErrorCode : ErrorCode
{
    private const string CoreCode = "Enrollment";

    public static readonly ErrorCode NotFound = new NotFoundError();

    protected EnrollmentErrorCode(string code, string message) : base(code, message)
    {
    }

    private sealed class NotFoundError : ErrorCode
    {
        public NotFoundError() : base($"{CoreCode}.NotFound", "Enrollment was not found")
        {
        }
    }
}
