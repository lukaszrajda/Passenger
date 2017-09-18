using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Services;

namespace Passenger.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        private readonly IJwtHandler _jwtHandler;
        private readonly IUserService _userService;
        public AccountController(IUserService userService, 
            ICommandDispatcher commandDispatcher,
            IJwtHandler jwtHandler) : base(commandDispatcher)
        {
            _jwtHandler = jwtHandler;
            _userService = userService;
        }

        [HttpGet]
        [Route("token/{email}")]
        public IActionResult Get(string email)
        {
           var token = _jwtHandler.CreateToken(email, "admin");
           return Json(token);
        }

        [HttpPut]
        [Route("password")]
        public async Task<IActionResult> Put([FromBody]ChangeUserPassword command)
        {
            await CommandDispatcher.DispatchAsync(command);
            return NoContent();
        }
        
    }
}