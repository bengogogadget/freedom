using bengogogadget.core.Infrastructure.Interfaces;

using System;

namespace bengogogadget.core.Infrastructure
{
    public class UuidGenerator : IUuidGenerator
    {
        public string GenerateUuid()
        {
            return Guid.NewGuid().ToString().ToLowerInvariant();
        }
    }
}
