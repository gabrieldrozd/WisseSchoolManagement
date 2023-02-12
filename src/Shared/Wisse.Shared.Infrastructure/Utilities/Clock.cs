using Wisse.Shared.Abstractions.Utilities;

namespace Wisse.Shared.Infrastructure.Utilities;

internal sealed class Clock : IClock
{
    public DateTime Current()
        => DateTime.Now;
}
