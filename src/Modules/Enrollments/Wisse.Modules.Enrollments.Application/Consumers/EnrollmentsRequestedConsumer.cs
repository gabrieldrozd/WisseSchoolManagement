using MassTransit;
using Microsoft.Extensions.Logging;
using Wisse.Contracts.EnrollmentsRequested;

namespace Wisse.Modules.Enrollments.Application.Consumers;

public class EnrollmentsRequestedConsumer : IConsumer<EnrollmentsRequested>
{
    private readonly ILogger<EnrollmentsRequestedConsumer> _logger;

    public EnrollmentsRequestedConsumer(ILogger<EnrollmentsRequestedConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<EnrollmentsRequested> context)
    {
        _logger.LogInformation("Received Enrollment with '{Status}' status", context.Message.Enrollment.EnrollmentStatus);
        return Task.CompletedTask;
    }
}
