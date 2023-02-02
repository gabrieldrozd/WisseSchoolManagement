using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Wisse.Shared.Abstractions.Modules.Communication;
using Wisse.Shared.Infrastructure.Communication.Messaging.Channels;

namespace Wisse.Shared.Infrastructure.Communication.Messaging;

internal sealed class BackgroundDispatcher : BackgroundService
{
    private readonly ILogger<BackgroundDispatcher> _logger;
    private readonly IMessageChannel _messageChannel;
    private readonly IModuleClient _moduleClient;

    public BackgroundDispatcher(
        ILogger<BackgroundDispatcher> logger,
        IMessageChannel messageChannel,
        IModuleClient moduleClient)
    {
        _logger = logger;
        _messageChannel = messageChannel;
        _moduleClient = moduleClient;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Running the background message dispatcher");

        await foreach (var message in _messageChannel.Reader.ReadAllAsync(stoppingToken))
        {
            try
            {
                await _moduleClient.PublishAsync(message);
                _logger.LogInformation("Published message {Message}", message.GetType().Name);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
            }
        }
    }
}