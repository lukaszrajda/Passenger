using System;
using System.Threading.Tasks;
using Passenger.Core.Domain;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public interface IDriverService
    {
         Task<DriverDto> GetAsync(Guid userId);
         Task RegisterAsync(Guid userId);         
    }
}