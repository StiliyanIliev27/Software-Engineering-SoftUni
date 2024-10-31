using NUnit.Framework;

namespace VehicleGarage.Tests
{
    public class VehicleTests
    {

        [Test]
        public void VehicleConstructorShouldInitializeCorrectlyAllValues()
        {
            Vehicle vehicle = new Vehicle("VW", "Golf", "PB7777AM");

            Assert.AreEqual("VW", vehicle.Brand);
            Assert.AreEqual("Golf", vehicle.Model);
            Assert.AreEqual("PB7777AM", vehicle.LicensePlateNumber);
            Assert.AreEqual(100, vehicle.BatteryLevel);
            Assert.IsFalse(vehicle.IsDamaged);
        }
    }
}