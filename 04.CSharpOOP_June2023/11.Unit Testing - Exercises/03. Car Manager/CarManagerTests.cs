namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        [TestCase("Audi", "A8", 5, 100)]
        [TestCase("BMW", "X5", 8, 41)]
        public void CarConstructorShouldWorkCorrectly(string expectedMake, string expectedModel,
            double expectedFuelConsumption, double expectedFuelCapacity)
        {
            Car car = new Car(expectedMake, expectedModel, expectedFuelConsumption, expectedFuelCapacity);

            Assert.AreEqual(expectedMake, car.Make);
            Assert.AreEqual(expectedModel, car.Model);
            Assert.AreEqual(expectedFuelConsumption, car.FuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [TestCase(null)]
        [TestCase("")]
        public void CarConstructorShouldThrowAxExceptionIfMakeIsNullOrEmpty(string make)
        {
            ArgumentException argumentException = 
                Assert.Throws<ArgumentException>(() => new Car(make, "A8", 5, 100));

            Assert.AreEqual("Make cannot be null or empty!", argumentException.Message);
        }
       
        [TestCase(null)]
        [TestCase("")]
        public void CarConstructorShouldThrowAxExceptionIfModelIsNullOrEmpty(string model)
        {
            ArgumentException argumentException =
                Assert.Throws<ArgumentException>(() => new Car("Audi", model, 5, 100));

            Assert.AreEqual("Model cannot be null or empty!", argumentException.Message);
        }

        [TestCase(-5)]
        [TestCase(0)]
        public void CarConstructorShouldThrowAxExceptionIfFuelConsumptionIsNegativeOrZero(double fuelConsumption)
        {
            ArgumentException argumentException =
                Assert.Throws<ArgumentException>(() => new Car("Audi", "A8", fuelConsumption, 100));

            Assert.AreEqual("Fuel consumption cannot be zero or negative!", argumentException.Message);
        }

        [TestCase(-5)]
        [TestCase(0)]
        public void CarConstructorShouldThrowAxExceptionIfFuelCapacityIsNegativeOrZero(double fuelCapacity)
        {
            ArgumentException argumentException =
                Assert.Throws<ArgumentException>(() => new Car("Audi", "A8", 5.5, fuelCapacity));

            Assert.AreEqual("Fuel capacity cannot be zero or negative!", argumentException.Message);
        }

        [Test]
        public void CarRefuelShouldIncreaseFuelAmount()
        {
            Car car = new Car("Audi", "A8", 5, 100);

            car.Refuel(5);

            Assert.AreEqual(car.FuelAmount, 5);
        }

        [Test]
        public void CarRefuelShouldShouldSetFuelAmountToFuelCapacityIfFuelAmountIsMoreThanFuelCapacity()
        {
            Car car = new Car("Audi", "A8", 5, 20);

            car.Refuel(21);

            Assert.AreEqual(car.FuelAmount, 20);
        }

        [TestCase(-6)]
        [TestCase(0)]
        public void CarRefuelShouldThrowAnExceptionIfFuelToRefuelIsNegativeOrZero(double fuelToRefuel)
        {
            Car car = new Car("Audi", "A8", 5, 20);

            ArgumentException argumentException =
                Assert.Throws<ArgumentException>(() => car.Refuel(fuelToRefuel));

            Assert.AreEqual("Fuel amount cannot be zero or negative!", argumentException.Message);
        }

        [Test]
        public void CarDriveShouldDecreaseFuelAmount()
        {
            Car car = new Car("Audi", "A8", 5, 20);

            car.Refuel(10);
            car.Drive(10);

            Assert.AreEqual(9.5, car.FuelAmount);
        }

        [Test]
        public void CarDriveShouldThrownAnExceptionIfFuelNeededIsMoreThanFuelAmount()
        {
            Car car = new Car("Audi", "A8", 5, 20);

            car.Refuel(0.3);
            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => car.Drive(10));

            Assert.AreEqual("You don't have enough fuel to drive!", exception.Message);
        }
    }
}