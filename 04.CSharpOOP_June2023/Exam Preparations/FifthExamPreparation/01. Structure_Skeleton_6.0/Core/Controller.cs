using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private IRepository<IHotel> hotels;
        public Controller()
        {
            hotels = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            IHotel hotel = hotels.Select(hotelName);

            if(hotel != null)
            {
                return $"Hotel {hotelName} is already registered in our platform.";
            }

            hotel = new Hotel(hotelName, category);
            hotels.AddNew(hotel);

            return $"{category} stars hotel {hotelName} is registered in our platform and expects room availability to be uploaded.";
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            if(hotels.All().FirstOrDefault(h => h.Category == category) == null)
            {
                return $"{category} star hotel is not available in our platform.";
            }

            IEnumerable<IHotel> orderedHotels = hotels.All()
                .Where(x => x.Category == category)
                .OrderBy(x => x.FullName);

            foreach(var hotel in orderedHotels)
            {
                var selectedRoom = hotel.Rooms.All()
                    .Where(h => h.PricePerNight > 0)
                    .OrderBy(h => h.BedCapacity)
                    .FirstOrDefault(h => h.BedCapacity >= adults + children);

                if(selectedRoom != null)
                {
                    int bookingNumber = this.hotels.All().Sum(x => x.Bookings.All().Count) + 1;
                    IBooking booking = new Booking(selectedRoom, duration, adults, children, bookingNumber);
                    hotel.Bookings.AddNew(booking);
                    return $"Booking number {bookingNumber} for {hotel.FullName} hotel is successful!";
                }
            }

            return $"We cannot offer appropriate room for your request.";
        }
         
        public string HotelReport(string hotelName)
        {
            IHotel hotel = hotels.Select(hotelName);

            if (hotel == null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Hotel name: {hotel.FullName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:F2} $");
            sb.AppendLine($"--Bookings:");
            sb.AppendLine();

            if (hotel.Bookings.All().Count == 0)
            {
                sb.AppendLine("none");
            }
            else
            {
                foreach (var booking in hotel.Bookings.All())
                {
                    sb.AppendLine($"{booking.BookingSummary()}");
                    sb.AppendLine();
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotel = hotels.All().FirstOrDefault(h => h.FullName == hotelName);

            if (hotel == null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }

            if (roomTypeName != nameof(Apartment) && roomTypeName != nameof(DoubleBed) && roomTypeName != nameof(Studio))
            {
                throw new ArgumentException("Incorrect room type!");
            }

            if(hotel.Rooms.Select(roomTypeName) == null)
            {
                return "Room type is not created yet!";
            }

            IRoom room = hotel.Rooms.Select(roomTypeName);

            if(room.PricePerNight > 0) 
            {
                throw new InvalidOperationException("Price is already set!");
            }

            room.SetPrice(price);

            return $"Price of {roomTypeName} room type in {hotelName} hotel is set!";
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            IHotel hotel = hotels.All().FirstOrDefault(h => h.FullName == hotelName);
            
            if(hotel == null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }

            IRoom room = hotels.Select(hotelName).Rooms.Select(roomTypeName);

            if(room != null)
            {
                return "Room type is already created!";
            }

            if(roomTypeName != nameof(Apartment) && roomTypeName != nameof(DoubleBed) && roomTypeName != nameof(Studio))
            {
                return "Incorrect room type!";
            }

            if(roomTypeName == nameof(Apartment))
            {
                room = new Apartment();
            }
            else if (roomTypeName == nameof(DoubleBed))
            {
                room = new DoubleBed();
            }
            else
            {
                room = new Studio();
            }

            hotel.Rooms.AddNew(room);
            return $"Successfully added {room.GetType().Name} room type in {hotelName} hotel!";
        }
    }
}
