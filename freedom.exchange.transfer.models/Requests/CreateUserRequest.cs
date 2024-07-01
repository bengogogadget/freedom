using Microsoft.AspNetCore.Mvc;
using System;

namespace freedom.exchange.transfer.models.Requests
{
    public class CreateUserRequest
    {
        [FromBody]
        public string Name { get; set; }

        [FromBody]
        public string PhoneNumber { get; set; }

        [FromBody]
        public string Email { get; set; }

        [FromBody]
        public DateTime DateOfBirth { get; set; }
    }
}
