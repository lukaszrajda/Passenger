using System;

namespace Passenger.Core.Domain
{
    public class Vehicle
    {
        public string Brand { get; protected set; }
        public string Name { get; protected set; }
        public int Seats { get; protected set; }

        protected Vehicle()
        {

        }
        protected Vehicle(string brand, string name, int seats)
        {
            SetBrand(brand);
            SetName(name);
            SetSeats(seats);
        }

        private void SetBrand(string brand)
        {
            if (string.IsNullOrWhiteSpace(brand))
            {
                throw new Exception("Please provide valid car brand name."); 
            }
            if (Brand == brand)
            {
                return;
            }
            Brand = brand;
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Please provide valid car name."); 
            }
            if (Name == name)
            {
                return;
            }
            Name = name;
        }

        private void SetSeats(int seats)
        {
            if (seats < 2)
            {
                throw new Exception("Seats quantity is too low."); 
            }
            if (seats > 9)
            {
                throw new Exception("Ypu can not provide more than 9 seats."); 
            }
            if (seats == Seats)
            {
                return;
            }
            Seats = seats;
        }

        public static Vehicle Create(string brand, string name, int seats)
            => new Vehicle(brand, name, seats);
    }
}