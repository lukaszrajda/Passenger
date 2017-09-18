using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Passenger.Api;
using Passenger.Infrastructure.DTO;

namespace Passenger.Tests.EndToEnd.Controllers
{
    public abstract class ControllerTestsBase
    {
        protected readonly TestServer Server;
        protected readonly HttpClient Client;

        protected ControllerTestsBase()
        {
            Server = new TestServer(new WebHostBuilder()
                        .UseStartup<Startup>());
            Client = Server.CreateClient();
        } 
        protected static StringContent GetPayLoad(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        protected async Task<UserDto> GetUserAsync(string email)
        {
            var response = await Client.GetAsync($"users/{email}");

            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserDto>(responseString);
        }
    }
}