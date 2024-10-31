using NUnit.Framework;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace RobotFactory.Tests
{
    public class Tests
    {
        private Factory factory;
        
        [SetUp]
        public void Setup()
        {
            factory = new("Petko", 3);
        }

        [Test]
        public void FactoryConstructorShouldInitializeCorrectly()
        {
            string expectedName = "Petko";
            int expectedCapacity = 3;

            Assert.AreEqual(expectedName, factory.Name);
            Assert.AreEqual(expectedCapacity, factory.Capacity);
            Assert.IsNotNull(factory.Robots);
            Assert.IsNotNull(factory.Supplements);
        }

        [Test]
        public void FactoryRobotsNameSetterShouldWorkCorrectly()
        {
            string expectedName = "Peter";

            factory.Name = expectedName;

            Assert.AreEqual(expectedName, factory.Name);
        }

        [Test]
        public void FactoryRobotsCapacitySetterShouldWorkCorrectly()
        {
            int expectedCapacity = 2;

            factory.Capacity = 2;

            Assert.AreEqual(expectedCapacity, factory.Capacity);
        }

        [Test]
        public void FactoryProduceRobotShouldAddRobotProperly()
        {
            Robot expectedRobot = new("Terminator", 550.50, 20);
            
            string expectedMessage = 
                $"Produced --> Robot model: {expectedRobot.Model} IS: {expectedRobot.InterfaceStandard}, Price: {expectedRobot.Price:f2}";

            string actualMessage = factory
                .ProduceRobot(expectedRobot.Model, 
                expectedRobot.Price, expectedRobot.InterfaceStandard);

            Robot actualRobot = factory.Robots.First();
            
            Assert.AreEqual(expectedRobot.Model, actualRobot.Model);
            Assert.AreEqual(expectedRobot.Price, actualRobot.Price);
            Assert.AreEqual(expectedRobot.InterfaceStandard, actualRobot.InterfaceStandard);
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void FactoryProduceRobotShouldNotAddRobotIfCapacityIsBiggerThanCount()
        {
            string expectedMessage = 
                "The factory is unable to produce more robots for this production day!";

            factory.Capacity = 0;

            string actualMessage = factory.ProduceRobot("Teri", 400, 25);

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void FactoryProduceSupplementShouldAddSupplementProperlyAndReturnSupplementToString()
        {
            Supplement expectedSupplement = new("Lazer", 20);
            
            string actualMessage = factory
                .ProduceSupplement(expectedSupplement.Name, 
                expectedSupplement.InterfaceStandard);

            string expectedMessage = 
                $"Supplement: {expectedSupplement.Name} IS: {expectedSupplement.InterfaceStandard}";

            Supplement actualSupplement = factory.Supplements.First();

            Assert.AreEqual(expectedMessage, actualMessage);
            Assert.AreEqual(expectedSupplement.Name, actualSupplement.Name);
            Assert.AreEqual(expectedSupplement.InterfaceStandard, actualSupplement.InterfaceStandard);
        }

        [Test]
        public void FactoryUpgradeRobotShouldAddSupplementsProperlyAndReturnTrue()
        {
            Robot robot = new("Terminator", 550.50, 20);
            Supplement expectedsupplement = new("Lazer", 20);

            bool result = factory.UpgradeRobot(robot, expectedsupplement);           

            Assert.AreEqual(robot.Supplements.First(), expectedsupplement);
            Assert.IsTrue(result);
        }

        [Test]
        public void FactoryUpgradeRobotShouldReturnFalseIfRobotContainsCurrentSupplement()
        {
            Robot robot = new("Terminator", 550.50, 20);
           
            robot.Supplements.Add(new Supplement("Lazer", 10));
           
            Supplement expectedsupplement = new("Lazer", 10);

            bool result = factory.UpgradeRobot(robot, expectedsupplement);
            
            Assert.IsFalse(result);
        }

        [Test]
        public void FactoryUpgradeRobotShouldReturnFalseIfRobotInterfaceStandardIsNotSameAsSupplementInterfaceStandard()
        {
            Robot robot = new("Terminator", 550.50, 20);

            Supplement expectedsupplement = new("Lazer", 15);

            bool result = factory.UpgradeRobot(robot, expectedsupplement);

            Assert.IsFalse(result);
        }

        [Test]
        public void FactorySellRobotShouldReturnCorrectRobot()
        {
            Robot expectedRobot = new("Terminator", 550, 26);

            Supplement expectedsupplement = new("Lazer", 15);

            _ = factory.ProduceRobot(expectedRobot.Model, expectedRobot.Price, expectedRobot.InterfaceStandard);
            _ = factory.ProduceRobot("Terminator 2", 1000 , 25);
            _ = factory.ProduceRobot("Terminator 3", 780, 10);

            Robot actualRobot = factory.SellRobot(600);

            Assert.AreEqual(expectedRobot.Model, actualRobot.Model);
            Assert.AreEqual(expectedRobot.Price, actualRobot.Price);
            Assert.AreEqual(expectedRobot.InterfaceStandard, actualRobot.InterfaceStandard);
        }
    }
}