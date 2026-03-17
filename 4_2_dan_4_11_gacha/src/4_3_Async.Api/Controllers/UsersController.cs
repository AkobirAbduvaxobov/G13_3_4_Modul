using _4_3_Async.Api.Dtos;
using _4_3_Async.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _4_3_Async.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersBroker UsersBroker;

        public UsersController()
        {
            UsersBroker = new UsersBroker();
        }

        [HttpPost]
        public async Task<string> Create(UserDto userDto)
        {
            return await UsersBroker.CreateAsync(userDto);
        }
    }
}
