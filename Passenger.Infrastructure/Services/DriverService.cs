using System;
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
        public DriverDto Get(Guid userId)
        {
            var driver = _driverRepository.Get(userId);
            return new DriverDto
            {
                UserId = driver.UserId,
                Vehicle = driver.Vehicle
            };
        }
        public void Register(Guid userId)
        {
            var driver = _driverRepository.Get(userId);
            if(driver != null)
            {
                throw new Exception($"Driver with already exists.");
            }
            var salt = Guid.NewGuid().ToString("N");
            driver = new Driver(userId);
            _driverRepository.Add(driver);
        }
    }
}