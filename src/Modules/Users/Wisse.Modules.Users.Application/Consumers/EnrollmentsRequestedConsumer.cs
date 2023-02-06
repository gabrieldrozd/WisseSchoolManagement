using MassTransit;
using Microsoft.Extensions.Logging;
using Wisse.Contracts.EnrollmentsRequested;

namespace Wisse.Modules.Users.Application.Consumers;

public class EnrollmentsRequestedConsumer : IConsumer<EnrollmentsRequested>
{
    private readonly ILogger<EnrollmentsRequestedConsumer> _logger;

    public EnrollmentsRequestedConsumer(ILogger<EnrollmentsRequestedConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<EnrollmentsRequested> context)
    {
        _logger.LogInformation("Enrollment added on: {Date:F}", context.Message.Enrollment.EnrollmentDate);
        return Task.CompletedTask;
    }
}
