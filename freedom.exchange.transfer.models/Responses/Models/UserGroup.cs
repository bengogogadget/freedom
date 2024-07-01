using System;

namespace freedom.exchange.transfer.models.Responses.Models
{
    public class UserGroup
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Hash { get; set; }

        public DateTime? UtcRemoved { get; set; }
    }
}
