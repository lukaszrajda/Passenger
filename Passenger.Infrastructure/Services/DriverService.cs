using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Extensions;

namespace Passenger.Infrastructure.Services
{
    public class DriverSerice : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IVehicleProvider _vehicleProvider;
        public DriverSerice(IDriverRepository driverRepository, IUserRepository userRepository,
            IMapper mapper, IVehicleProvider vehicleProvider)
        {
            _driverRepository = driverRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _vehicleProvider = vehicleProvider;
        }

        public async Task<IEnumerable<DriverDto>> BrowseAsync()
        {
            var drivers = await _driverRepository.BrowseAsync();
            return _mapper.Map<IEnumerable<DriverDto>>(drivers);
        }

        public async Task DeleteDriver(Guid userId)
        {
            var driver = await _driverRepository.GetOrFailAsync(userId);
            await _driverRepository.DeleteAsync(driver);
        }

        public async Task<DriverDetailDto> GetAsync(Guid userId)
        {
            var driver = await _driverRepository.GetOrFailAsync(userId);
            return _mapper.Map<DriverDetailDto>(driver);
        }
        public async Task RegisterAsync(Guid userId)
        {
            var user = await _userRepository.GetOrFailAsync(userId);
            var driver = await _driverRepository.GetAsync(userId);
            if(driver != null)
            {
                throw new Exceptions.ServiceException(Exceptions.ErrorCodes.DriverAlreadyExists, $"Driver with user ID: '{userId}' already exists.");
            }
            driver = new Driver(user);
            await _driverRepository.AddAsync(driver);
        }

        public async Task SetVehicleAsync(Guid userId, string brand, string name)
        {
            var driver = await _driverRepository.GetOrFailAsync(userId);
            var vehicleDetails = await _vehicleProvider.GetAsync(brand, name);
            var vehicle = Vehicle.Create(brand, name, vehicleDetails.Seats);
            driver.SetVehicle(vehicle);
            await _driverRepository.UpdateAsync(driver);
        }
    }
}