using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Passenger.Core.Domain;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public interface IDriverService : IService
    {
        Task<DriverDto> GetAsync(Guid userId);
        Task RegisterAsync(Guid userId);     
        Task SetVehicleAsync(Guid userId, string brand, string name, int seats);
        Task<IEnumerable<DriverDto>> BrowseAsync();
    }
}