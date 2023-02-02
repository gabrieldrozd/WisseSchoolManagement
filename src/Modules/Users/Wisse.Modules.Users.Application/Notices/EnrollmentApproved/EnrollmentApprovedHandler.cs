using Microsoft.Extensions.Logging;
using Wisse.Shared.Abstractions.Communication.External.Notices;

namespace Wisse.Modules.Users.Application.Notices.EnrollmentApproved;

internal class EnrollmentApprovedHandler : INoticeHandler<EnrollmentApproved>
{
    private readonly ILogger<EnrollmentApprovedHandler> _logger;

    public EnrollmentApprovedHandler(ILogger<EnrollmentApprovedHandler> logger)
    {
        _logger = logger;
    }

    public async Task HandleAsync(EnrollmentApproved notice)
    {
        _logger.LogInformation(notice.Enrollment.Applicant.FirstName);

        await Task.CompletedTask;
    }
}
