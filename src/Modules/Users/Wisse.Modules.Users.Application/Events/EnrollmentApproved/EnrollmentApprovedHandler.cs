using Microsoft.Extensions.Logging;
using Wisse.Shared.Abstractions.Communication.External.Events;

namespace Wisse.Modules.Users.Application.Events.EnrollmentApproved;

internal sealed class EnrollmentApprovedHandler : IEventHandler<EnrollmentApproved>
{
    private readonly ILogger<EnrollmentApprovedHandler> _logger;

    public EnrollmentApprovedHandler(ILogger<EnrollmentApprovedHandler> logger)
    {
        _logger = logger;
    }

    public async Task HandleAsync(EnrollmentApproved @event)
    {
        _logger.LogInformation(@event.Enrollment.Applicant.FirstName);

        await Task.CompletedTask;
    }
}
