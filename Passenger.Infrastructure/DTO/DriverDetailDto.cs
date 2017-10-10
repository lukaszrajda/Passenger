using System.Collections.Generic;

namespace Passenger.Infrastructure.DTO
{
    public class DriverDetailDto : DriverDto
    {
        public IEnumerable<RouteDto> Routes { get; set; }
    }
}