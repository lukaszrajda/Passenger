using System;
using System.Collections.Generic;
using System.Linq;

namespace Passenger.Core.Domain
{
    public class Driver // aggregate root
    {
        private ISet<Route> _routes = new HashSet<Route>();
        private ISet<DailyRoute> _dailyRoutes = new HashSet<DailyRoute>();
        public Guid UserId { get; protected set; }
        public string Name { get; protected set; }
        public Vehicle Vehicle { get; protected set; }
        public IEnumerable<Route> Routes  => _routes;
        public IEnumerable<DailyRoute> DailyRoutes => _dailyRoutes;
        public DateTime UpdatedAt { get; protected set; }
        protected Driver()
        {            
        }

        public Driver(User user)
        {
            UserId = user.Id;
            Name = user.UserName;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetVehicle(Vehicle vehicle)
        {
            Vehicle = vehicle;
            UpdatedAt = DateTime.UtcNow;
        }
        public void AddRoute(string name, Node startNode, Node endNode, double distance)
        {
            var route = Routes.SingleOrDefault(x => x.Name == name);
            if (route != null)
            {
                throw new Exception($"Route with name: '{name}' already exists for driver: '{Name}'.");
            }
            if (distance < 0)
            {
                throw new Exception($"Route with name: '{name}' can not have negative distance.");
            }
            _routes.Add(Route.Create(name, startNode, endNode, distance));
            UpdatedAt = DateTime.UtcNow;
        }

        public void DeleteRoute(string name)
        {
            var route = Routes.SingleOrDefault(x => x.Name == name);
            if (route == null)
            {
                throw new Exception($"Route with name: '{name}' for driver: '{Name}' does not exists.");
            }
            _routes.Remove(route);
            UpdatedAt = DateTime.UtcNow;
        }
    }
}