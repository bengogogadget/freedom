using bengogogadget.core.Infrastructure.Interfaces;

using System;

namespace bengogogadget.core.Infrastructure
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;

        public DateTime UtcDate => DateTime.UtcNow.Date;
    }
}
