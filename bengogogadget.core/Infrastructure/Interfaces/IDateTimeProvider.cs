using System;

namespace bengogogadget.core.Infrastructure.Interfaces
{
    public interface IDateTimeProvider
    {
        DateTime UtcDate { get; }

        DateTime UtcNow { get; }
    }
}