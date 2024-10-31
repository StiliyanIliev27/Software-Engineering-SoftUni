using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontDeskApp.Tests
{
    public class HotelTests
    {
        private Hotel hotel;

        [SetUp]
        public void Setup()
        {
            hotel = new Hotel("Viktoria", 4);
        }

        [Test]
        public void HotelContructorShouldWorkProperly()
        {
            string expectedFullName = hotel.FullName;
            int expectedCategory = hotel.Category;

            Assert.AreEqual(expectedFullName, hotel.FullName);
            Assert.AreEqual(expectedCategory, hotel.Category);
            Assert.IsNotNull(hotel.Bookings);
            Assert.IsNotNull(hotel.Rooms);
            Assert.AreEqual(0, hotel.Turnover);
        }

        [TestCase(" ")]
        [TestCase(null)]
        public void HotelFullNamePropShouldThrowAnExceptionIfValueIsNullOrWhiteSpace(string fullName)
        {
            ArgumentNullException ex = Assert
                .Throws<ArgumentNullException>(() => new Hotel(fullName, 5));

            Assert.IsTrue(ex.Message.Any());
        }

        [TestCase(0)]
        [TestCase(6)]
        public void HotelCategoryPropShouldThrowAnExceptionIfValueIsLessThanOneOrGreaterThan5(int category)
        {
            ArgumentException ex = Assert
                .Throws<ArgumentException>(() => new Hotel("viki", category));

            Assert.IsTrue(ex.Message.Any());
        }

        [Test]
        public void HotelShouldAddRoomProperly()
        {
            Room expectedRoom = new Room(5, 20);

            hotel.AddRoom(new Room(5, 20));

            Room actualRoom = hotel.Rooms.First();

            Assert.AreEqual(expectedRoom.BedCapacity, actualRoom.BedCapacity);
            Assert.AreEqual(expectedRoom.PricePerNight, actualRoom.PricePerNight);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void HotelBookRoomShouldThrowAnArgumentExceptionIfAdultsAreLessOrEqualToZero(int adults)
        {
            ArgumentException ex = Assert
                .Throws<ArgumentException>(() => hotel.BookRoom(adults, 1, 2, 10));

            Assert.IsTrue(ex.Message.Any());
        }

        [TestCase(-1)]
        public void HotelBookRoomShouldThrowAnArgumentExceptionIfChildrenAreLessThanZero(int children)
        {
            ArgumentException ex = Assert
                .Throws<ArgumentException>(() => hotel.BookRoom(1, children, 2, 10));

            Assert.IsTrue(ex.Message.Any());
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void HotelBookRoomShouldThrowAnArgumentExceptionIfResidentDurationIsLessThan1(int residenceDuration)
        {
            ArgumentException ex = Assert
                .Throws<ArgumentException>(() => hotel.BookRoom(1, 3, residenceDuration, 10));

            Assert.IsTrue(ex.Message.Any());
        }

        [Test]
        public void HotelBookRoomShouldWorkCorrectly()
        {
            Room room = new Room(5, 10);

            hotel.AddRoom(room);// 5 capacity

            hotel.BookRoom(1, 3, 3, 40);//4 people

            Booking expectedBooking = new Booking(hotel.Bookings.Count, room, 3);
            Booking actualBooking = hotel.Bookings.First();

            Assert.AreEqual(expectedBooking.BookingNumber, actualBooking.BookingNumber);
            Assert.AreEqual(expectedBooking.ResidenceDuration, actualBooking.ResidenceDuration);
            Assert.AreEqual(expectedBooking.Room.BedCapacity, actualBooking.Room.BedCapacity);
            Assert.AreEqual(expectedBooking.Room.PricePerNight, actualBooking.Room.PricePerNight);
            Assert.AreEqual(30, hotel.Turnover);
        }
    }
}