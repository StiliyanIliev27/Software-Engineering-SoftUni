using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleGarage.Tests
{
    public class GarageTests
    {
        [Test]
        public void GarageConstructorShouldInitializeCorrectlyAllValues()
        {
            Garage garage = new Garage(3);

            Assert.AreEqual(3, garage.Capacity);
            Assert.IsNotNull(garage.Vehicles);
        }

        [TestCase(3, "VW", "Golf", "CB7777PB")]
        public void GarageShouldAddVehiclesCorrectly(int capacity, string brand, string model, string licensePlateNumber)
        {
            Garage garage = new Garage(capacity);
            Vehicle vehicle = new Vehicle(brand, model, licensePlateNumber);

            bool result = garage.AddVehicle(vehicle);

            Assert.IsTrue(result);
            Assert.Contains(vehicle, garage.Vehicles);
        }

        [Test]
        public void GarageAddVehicleMethodShouldReturnFalseIfCapacityIsEqualToVehicleCount()
        {
            Garage garage = new Garage(2);
            
            Vehicle firstVehicle = new Vehicle("BMW","M4","PB1234GH");
            Vehicle secondVehicle = new Vehicle("Audi", "A5", "A1254GH");
            Vehicle thirdVehicle = new Vehicle("Mercedes-Benz", "G-Class", "CB1734GH");

            garage.AddVehicle(firstVehicle);
            garage.AddVehicle(secondVehicle);
            bool result = garage.AddVehicle(thirdVehicle);

            Assert.IsFalse(result);
        }

        [Test]
        public void GarageAddVehicleMethodShouldReturnFalseIfLicensePlateNumberIsAlreadyContained()
        {
            Garage garage = new Garage(3);

            Vehicle firstVehicle = new Vehicle("BMW", "M4", "PB1234GH");
            Vehicle secondVehicle = new Vehicle("Audi", "A5", "A1254GH");
            Vehicle thirdVehicle = new Vehicle("Mercedes-Benz", "G-Class", "PB1234GH");

            garage.AddVehicle(firstVehicle);
            garage.AddVehicle(secondVehicle);
            bool result = garage.AddVehicle(thirdVehicle);

            Assert.IsFalse(result);
        }

        [Test]
        public void GarageChargeVehiclesShouldWorkCorrectly()
        {
            Garage garage = new Garage(2);
            Vehicle firstVehicle = new Vehicle("BMW", "M4", "PB1234GH");
            Vehicle secondVehicle = new Vehicle("Audi", "A5", "A1254GH");

            garage.AddVehicle(firstVehicle);
            garage.AddVehicle(secondVehicle);
         
            garage.DriveVehicle("PB1234GH", 80, false);//20
            garage.DriveVehicle("A1254GH", 60, false);//40

            int result = garage.ChargeVehicles(30);

            Assert.AreEqual(1, result);
            Assert.AreEqual(100, firstVehicle.BatteryLevel);
            Assert.AreEqual(40, secondVehicle.BatteryLevel);           
        }

        [Test]
        public void GarageDriveVehicleShouldDecreaseBatteryLevel()
        {
            Garage garage = new Garage(2);
            Vehicle firstVehicle = new Vehicle("BMW", "M4", "PB1234GH");
            Vehicle secondVehicle = new Vehicle("Audi", "A5", "A1254GH");

            garage.AddVehicle(firstVehicle);
            garage.AddVehicle(secondVehicle);

            garage.DriveVehicle("PB1234GH", 80, false);//20
            garage.DriveVehicle("A1254GH", 60, false);//40

            Assert.AreEqual(20, firstVehicle.BatteryLevel);
            Assert.AreEqual(40, secondVehicle.BatteryLevel);
        }

        [Test]
        public void GarageDriveVehicleShouldChangeIsDamagedPropToTrueIfAccidentOccuredIsTrueOrStayFalseIfAccidentNotOccured()
        {
            Garage garage = new Garage(2);
            Vehicle firstVehicle = new Vehicle("BMW", "M4", "PB1234GH");
            Vehicle secondVehicle = new Vehicle("Audi", "A5", "A1254GH");

            garage.AddVehicle(firstVehicle);
            garage.AddVehicle(secondVehicle);

            garage.DriveVehicle("PB1234GH", 80, true);
            garage.DriveVehicle("A1254GH", 60, false);

            Assert.AreEqual(true, firstVehicle.IsDamaged);
            Assert.AreEqual(false, secondVehicle.IsDamaged);
        }

        [Test]
        public void GarageDriveVehicleShouldChangeNothingIfVehicleIsDamaged()
        {
            Garage garage = new Garage(1);
            Vehicle firstVehicle = new Vehicle("BMW", "M4", "PB1234GH");

            garage.AddVehicle(firstVehicle);
           
            firstVehicle.IsDamaged = true;
            garage.DriveVehicle("PB1234GH", 80, false);

            Assert.AreEqual(100, firstVehicle.BatteryLevel);
        }

        [Test]
        public void GarageDriveVehicleShouldChangeNothingIfVehicleDrainageIsMoreThan100()
        {
            Garage garage = new Garage(1);
            Vehicle firstVehicle = new Vehicle("BMW", "M4", "PB1234GH");

            garage.AddVehicle(firstVehicle);

            garage.DriveVehicle("PB1234GH", 120, false);

            Assert.AreEqual(100, firstVehicle.BatteryLevel);
        }

        [Test]
        public void GarageDriveVehicleShouldChangeNothingIfBatteryLevelIsLessThanBatteryDrainage()
        {
            Garage garage = new Garage(1);
            Vehicle firstVehicle = new Vehicle("BMW", "M4", "PB1234GH");

            garage.AddVehicle(firstVehicle);

            firstVehicle.BatteryLevel = 80;
            garage.DriveVehicle("PB1234GH", 90, false);

            Assert.AreEqual(80, firstVehicle.BatteryLevel);
        }

        [Test]
        public void GarageRepairVehiclesShouldChangeIsDamagedToFalseCorrectly()
        {
            Garage garage = new Garage(2);
            Vehicle firstVehicle = new Vehicle("BMW", "M4", "PB1234GH");
            Vehicle secondVehicle = new Vehicle("Audi", "A8", "PB1634GH");

            garage.AddVehicle(firstVehicle);
            garage.AddVehicle(secondVehicle);

            garage.DriveVehicle("PB1234GH", 60, true);
            garage.DriveVehicle("PB1634GH", 50, true);

            garage.RepairVehicles();

            Assert.IsFalse(firstVehicle.IsDamaged);
            Assert.IsFalse(secondVehicle.IsDamaged);
        }

        [Test]
        public void GarageRepairVehiclesShouldIncreaseRepairedVehiclesCorrectly()
        {
            Garage garage = new Garage(2);
            Vehicle firstVehicle = new Vehicle("BMW", "M4", "PB1234GH");
            Vehicle secondVehicle = new Vehicle("Audi", "A8", "PB1634GH");

            garage.AddVehicle(firstVehicle);
            garage.AddVehicle(secondVehicle);

            garage.DriveVehicle("PB1234GH", 60, true);
            garage.DriveVehicle("PB1634GH", 50, true);

            Assert.AreEqual("Vehicles repaired: 2", garage.RepairVehicles());
        }
    }
}
