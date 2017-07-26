using System;

namespace Passenger.Core.Domain
{
    public class Node
    {
        public string Address { get; protected set; }
        public double Longitude  { get; protected set; }
        public double Latitude  { get; protected set; }
        public DateTime UpdatedAt { get; set; }

        protected Node()
        {

        }

        private Node(string address, double longitude, double latitude)
        {
            SetAddress(address);
            SetLongitude(longitude);
            SetLatitude(latitude);
        }

        protected void SetAddress(string address)
        {
            if (address == Address)
            {
                return;
            }
            Address = address;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetLongitude(double longitude)
        {
            if (longitude > 180 || longitude < -180)
            {
                throw new Exception($"Longitude {longitude} is not correct value.");
            }
            if (longitude == Longitude)
            {
                return;
            }
            Longitude = longitude;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetLatitude(double latitude)
        {
            if (latitude > 90 || latitude < -90)
            {
                throw new Exception($"Latitude {latitude} is not correct value.");
            }
            if (latitude == Latitude)
            {
                return;
            }
            Latitude = latitude;
            UpdatedAt = DateTime.UtcNow;
        }

        public static Node Create(string address, int longitude, int latitude)
            => new Node(address, longitude, latitude);
    }
}