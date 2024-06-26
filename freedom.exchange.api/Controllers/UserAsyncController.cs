﻿using freedom.exchange.api.Commands.Interfaces;
using freedom.exchange.transfer.models.Requests;
using freedom.exchange.transfer.models.Responses;

using Microsoft.AspNetCore.Mvc;

namespace freedom.exchange.api.Controllers
{
    [Route("api/user")]
    public class UserAsyncController(ICreateUser createUser) : FeController
    {
        [HttpPost]
        public async Task<CreateUserResponse> Post([FromBody] CreateUserRequest request)
        {
            return new CreateUserResponse
            {
                UserId = await createUser.ExecuteAsync(request)
            };
        }
    }
}
