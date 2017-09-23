using System;

namespace Passenger.Infrastructure.Commands.Users
{
    public class LoginUser : ICommand
    {
        public Guid TokenId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}