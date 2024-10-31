namespace FrontDeskApp.Tests
{
    public class BookingTests
    {
        [Test]
        public void BookingConstructorShouldInitializeCorrectly()
        {
            Booking booking = new Booking(5, new Room(10, 20), 7);

            int expectedBookingNumber = 5;
            Room expectedRoom = new Room(10, 20);
            int expectedDuration = 7;

            Assert.AreEqual(expectedBookingNumber, booking.BookingNumber);
            Assert.AreEqual(expectedRoom.BedCapacity, booking.Room.BedCapacity);
            Assert.AreEqual(expectedRoom.PricePerNight, booking.Room.PricePerNight);
            Assert.AreEqual(expectedDuration, booking.ResidenceDuration);
        }
    }
}