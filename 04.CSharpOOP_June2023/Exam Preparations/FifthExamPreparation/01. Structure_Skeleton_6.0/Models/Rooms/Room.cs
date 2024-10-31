using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models.Rooms
{
    public abstract class Room : IRoom
    {
        private double pricePerNight;

        public int BedCapacity { get; private set; }

        protected Room(int bedCapacity)
        {
            BedCapacity = bedCapacity;
            PricePerNight = 0;
        }

        public double PricePerNight
        {
            get => pricePerNight;
            set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be negative!");
                }
                pricePerNight = value;
            }                
        }

        public void SetPrice(double price)
        {
            PricePerNight = price;
        }
    }
}
