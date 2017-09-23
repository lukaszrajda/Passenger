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
            var email = "user1@email.com";
            var user = await GetUserAsync(email);
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