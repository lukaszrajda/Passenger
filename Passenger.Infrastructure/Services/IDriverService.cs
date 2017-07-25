using System;
using Passenger.Core.Domain;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public interface IDriverService
    {
         DriverDto Get(Guid userId);
         void Register(Guid userId);         
    }
}