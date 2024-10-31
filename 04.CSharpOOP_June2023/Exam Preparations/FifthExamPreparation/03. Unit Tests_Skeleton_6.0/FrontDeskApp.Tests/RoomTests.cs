using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontDeskApp.Tests
{
    public class RoomTests
    {
        [Test]
        public void RoomConstructorShouldWorkProperly()
        {
            Room room = new Room(4, 20);

            int expectedBedCapacity = room.BedCapacity;
            double expectedPricePerNight = room.PricePerNight;

            Assert.AreEqual(expectedBedCapacity, room.BedCapacity);
            Assert.AreEqual(expectedPricePerNight, room.PricePerNight);
        }
        
        [TestCase(0)]
        [TestCase(-1)]
        public void RoomBedCapacityShouldThrowAnExceptionIfValueIsLessOrEqualToZero(int bedCapacity)
        {            
           ArgumentException ex = Assert.Throws<ArgumentException>(() => new Room(bedCapacity, 20));

           Assert.IsTrue(ex.Message.Any());
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void RoomPricePerNightShoudlThrowAnExceptionIfValueIsLessOrEqualToZero(double pricePerNight)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => new Room(5, pricePerNight));

            Assert.IsTrue(ex.Message.Any());
        }

        [TestCase]
        public void RoomPricePerNightSetterShoudlWorkCorrectly()
        {
            Room room = new Room(5, 20);

            room.PricePerNight = 10;

            Assert.AreEqual(10, room.PricePerNight);
        }
    }
}
