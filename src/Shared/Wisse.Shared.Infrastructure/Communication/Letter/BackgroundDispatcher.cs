using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Wisse.Shared.Abstractions.Modules.Communication;
using Wisse.Shared.Infrastructure.Communication.Letter.Channels;

namespace Wisse.Shared.Infrastructure.Communication.Letter;

internal sealed class BackgroundDispatcher : BackgroundService
{
    private readonly ILogger<BackgroundDispatcher> _logger;
    private readonly ILetterChannel _letterChannel;
    private readonly IModuleClient _moduleClient;

    public BackgroundDispatcher(
        ILogger<BackgroundDispatcher> logger,
        ILetterChannel letterChannel,
        IModuleClient moduleClient)
    {
        _logger = logger;
        _letterChannel = letterChannel;
        _moduleClient = moduleClient;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Running the background message dispatcher");

        await foreach (var letter in _letterChannel.Reader.ReadAllAsync(stoppingToken))
        {
            try
            {
                await _moduleClient.PublishAsync(letter);
                _logger.LogInformation("Published letter {Letter}", letter.GetType().Name);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
            }
        }
    }
}