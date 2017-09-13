using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Passenger.Api;
using Passenger.Infrastructure.Commands.Users;
using Xunit;

namespace Passenger.Tests.EndToEnd.Controllers
{
    public class AccountControllerTest : ControllerTestsBase
    {
        [Fact]
        public async Task given_valid_current_and_new_password_should_change()
        {
            var request = new ChangeUserPassword
            {
                CurrentPassword = "secret",
                NewPassword = "secret2"
            };
            var payload = GetPayLoad(request);
            var response = await Client.PutAsync("account/password", payload);
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NoContent);
        }
    }
}