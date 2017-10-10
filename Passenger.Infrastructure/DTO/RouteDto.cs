using System;

namespace Passenger.Infrastructure.DTO
{
    public class RouteDto
    {
        public Guid Id  { get; set; }
        public NodeDto StartNode { get; set; }
        public NodeDto EndNode { get; set; }   
        public double Distance { get; set; }       
    }
}