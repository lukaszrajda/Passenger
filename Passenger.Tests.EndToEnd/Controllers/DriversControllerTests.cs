using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Passenger.Infrastructure.Commands.Drivers;
using Passenger.Infrastructure.Commands.Users;
using Xunit;

namespace Passenger.Tests.EndToEnd.Controllers
{
    public class DriversControllerTests: ControllerTestsBase
    {

        [Fact]
        public async Task given_existing_userid_driver_should_be_added()
        {     
            var commandUser = new CreateUser
            {
                Email = "user5@email.com",
                UserName = "user5",
                Password = "secret"
            };
            var payloadUser = GetPayLoad(commandUser);
            var responseUser = await Client.PostAsync("users", payloadUser);
            var user = await GetUserAsync(commandUser.Email);
            responseUser.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Created);

            var commandDriver = new CreateDriver
            {
                UserId = user.Id
            };
            var payloadDriver = GetPayLoad(commandDriver);
            var responseDriver = await Client.PostAsync("drivers", payloadDriver);
            
            responseDriver.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Created);
            responseDriver.Headers.Location.ToString().ShouldBeEquivalentTo($"drivers/{commandDriver.UserId}");
        }
    }
}