using System;
using System.Collections.Generic;

namespace Passenger.Core.Domain
{
    public class Passenger
    {
        public Guid UserId { get; protected set; }
        public Node Address { get; protected set; }
        public Passenger(Guid userId)
        {
            UserId = userId;           
        }
    }
}