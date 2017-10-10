using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Passenger.Infrastructure.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IUserService _userService;
        private readonly IDriverService _driverService;
        private readonly IDriverRouteService _driverRouteService;
        private readonly ILogger<DataInitializer> _logger;
        public DataInitializer(IUserService userService, IDriverService driverService,
            IDriverRouteService driverRouteService, ILogger<DataInitializer> logger)
        {
            _userService = userService;
            _driverService = driverService;
            _logger = logger;
            _driverRouteService = driverRouteService;
        }
        public async Task SeedAsync()
        {
            _logger.LogTrace("Initializing data...");
            var tasks = new List<Task>();
            for (var i=1; i<=10; i++)
            {
                var userId = Guid.NewGuid();
                var username = $"user{i}";
                _logger.LogTrace($"Created a new user: '{username}'");
                tasks.Add(_userService.RegisterAsync(userId, $"{username}@email.com", 
                    username, "secret", "user"));
                tasks.Add(_driverService.RegisterAsync(userId));
                tasks.Add(_driverService.SetVehicleAsync(userId, "BMW", "i8"));
                _logger.LogTrace($"Created a new driver for: '{username}'.");
                tasks.Add(_driverRouteService.AddAsync(userId, "Default route", 1,1,2,2));
                tasks.Add(_driverRouteService.AddAsync(userId, "Job route", 3,4,7,8));
                _logger.LogTrace($"Adding route for: '{username}'.");

            }
            for (var i=1; i<=3; i++)
            {
                var userId = Guid.NewGuid();
                var username = $"admin{i}";
                _logger.LogTrace($"Created a new admin: '{username}'");
                tasks.Add(_userService.RegisterAsync(userId, $"{username}@email.com", 
                    username, "secret", "admin"));
            }
            await Task.WhenAll(tasks);
            _logger.LogTrace("Data was initialized.");
        }
    }
}