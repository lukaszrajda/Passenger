using System;
using System.Threading.Tasks;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public class DriverSerice : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        public DriverSerice(IDriverRepository driverRepository)
        {
            driverRepository = _driverRepository;
        }
        public async Task<DriverDto> GetAsync(Guid userId)
        {
            var driver = await _driverRepository.GetAsync(userId);
            return new DriverDto
            {
                UserId = driver.UserId,
                Vehicle = driver.Vehicle
            };
        }
        public async Task RegisterAsync(Guid userId)
        {
            var driver = await _driverRepository.GetAsync(userId);
            if(driver != null)
            {
                throw new Exception($"Driver with already exists.");
            }
            var salt = Guid.NewGuid().ToString("N");
            driver = new Driver(userId);
            await _driverRepository.AddAsync(driver);
        }
    }
}