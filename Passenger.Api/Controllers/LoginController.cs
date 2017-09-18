using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.Services;

namespace Passenger.Api.Controllers
{
    public class LoginController : ApiControllerBase
    {
        private readonly IJwtHandler _jwtHandler;
        private readonly IUserService _userService;
        public LoginController(IUserService userService, 
            ICommandDispatcher commandDispatcher,
            IJwtHandler jwtHandler) : base(commandDispatcher)
        {
            _jwtHandler = jwtHandler;
            _userService = userService;
        }
        
        [HttpPost("")]
        public async Task<IActionResult> Login([FromBody]LoginUser command)
        {
           await CommandDispatcher.DispatchAsync(command);
           var user = await _userService.GetAsync(command.Email);
           var token = _jwtHandler.CreateToken(command.Email, user.Role);
           return Json(token);
        }       
    }
}