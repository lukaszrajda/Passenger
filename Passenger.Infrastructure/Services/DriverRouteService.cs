using System;
using System.Threading.Tasks;
using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.Extensions;

namespace Passenger.Infrastructure.Services
{
    public class DriverRouteService : IDriverRouteService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;
        private readonly IRouteManager _routeManager;
        public DriverRouteService(IDriverRepository driverRepository,
            IMapper mapper, IRouteManager routeManager)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
            _routeManager = routeManager;
        }
        public async Task AddAsync(Guid userId, string name, double startLatitude, double startLongitude, double endLatitude, double endLongitude)
        {
            var driver = await _driverRepository.GetOrFailAsync(userId);
            var startAddress = await _routeManager.GetAdressAsync(startLatitude, startLongitude);
            var endAddress = await _routeManager.GetAdressAsync(endLatitude, endLongitude);

            var startNode = Node.Create(startAddress, startLongitude, startLatitude);
            var endNode = Node.Create(endAddress, endLongitude, endLatitude);
            var distance = _routeManager.CalculateDistance(startLatitude, startLongitude, 
                endLatitude, endLongitude);
            driver.AddRoute(name, startNode, endNode, distance);
            await _driverRepository.UpdateAsync(driver);
        }

        public async Task DeleteAsync(Guid userId, string name)
        {
            var driver = await _driverRepository.GetOrFailAsync(userId);
            driver.DeleteRoute(name);
            await _driverRepository.UpdateAsync(driver);
        }
    }
}