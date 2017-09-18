using System.Threading.Tasks;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.Services;

namespace Passenger.Infrastructure.Handlers.Accounts
{
    public class LoginUserHandler : ICommandHandler<LoginUser>
    {
        private readonly IUserService _userService;
        public LoginUserHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task HandleAsync(LoginUser command)
        {
            await _userService.LoginAsync(command.Email, command.Password);
        }

    }
}