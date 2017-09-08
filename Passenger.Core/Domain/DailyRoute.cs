using System;
using System.Collections.Generic;

namespace Passenger.Core.Domain
{
    public class DailyRoute
    {
        public Guid Id { get; protected set; }
        public Route Route { get; protected set; }
        public IEnumerable<PassengerNode> PassengerNodes { get; protected set; }
        public Driver Driver;
        public int Seats;
        protected DailyRoute()
        {
            
        }

        public DailyRoute(Route route, Driver driver)
        {
            Id = Guid.NewGuid();
            Route = route;
            Driver = driver;
            Seats = driver.Vehicle.Seats;
        }

        public void BookSeat(User user, Node startNode, Node endNode)
        {
            if (Seats < 1)
            {
                throw new Exception($"You canot book seat. Quantity of seats is too low.");
            }

            PassengerNode passengerNode = new PassengerNode(
                startNode,
                endNode,
                new Passenger(user.Id)
            );

            Seats -= 1;
        }
    }
    

}