using freedom.exchange.api.Commands.Interfaces;
using freedom.exchange.api.Dto;
using freedom.exchange.api.Responses;

using Microsoft.AspNetCore.Mvc;

namespace freedom.exchange.api.Controllers
{
    [Route("api/user")]
    public class UserController(ICreateUser createUser) : FeController
    {
        [HttpPost]
        public CreateUserResponse Post([FromBody] CreateUserRequest request)
        {
            return new CreateUserResponse
            {
                UserId = createUser.Execute(request)
            };
        }
    }
}
