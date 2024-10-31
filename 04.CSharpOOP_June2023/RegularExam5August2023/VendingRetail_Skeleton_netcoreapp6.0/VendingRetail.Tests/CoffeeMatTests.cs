using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace VendingRetail.Tests
{
    public class CoffeeMatTests
    {
        private CoffeeMat coffeeMat; 
        
        [SetUp]
        public void Setup()
        {
            coffeeMat = new CoffeeMat(20, 10);
        }

        [Test]
        public void CoffeeMatConstructorShouldInitializeCorrectly()
        {
            int expectedWaterCapacity = coffeeMat.WaterCapacity;
            int expectedButtonsCount = coffeeMat.ButtonsCount;
            double expectedIncome = coffeeMat.Income;

            FieldInfo waterTankLevelPrivateField = typeof(CoffeeMat)
               .GetField("waterTankLevel", BindingFlags.NonPublic | BindingFlags.Instance);
           
            int actualWaterTankLevelValue = (int)waterTankLevelPrivateField.GetValue(coffeeMat);

            FieldInfo drinks = typeof(CoffeeMat)
                .GetField("drinks", BindingFlags.NonPublic | BindingFlags.Instance);
           
            Dictionary<string, double> actualDrinksDictionary = (Dictionary<string, double>)drinks.GetValue(coffeeMat);

            Assert.AreEqual(expectedWaterCapacity, coffeeMat.WaterCapacity);
            Assert.AreEqual(expectedButtonsCount, coffeeMat.ButtonsCount);
            Assert.AreEqual(expectedIncome, coffeeMat.Income);
            Assert.AreEqual(0, actualWaterTankLevelValue);
            Assert.IsNotNull(actualDrinksDictionary);
        }
        
        [Test]
        public void CoffeeMatFillWaterTankShouldWorkCorrectly()
        {
            string actualMessage = coffeeMat.FillWaterTank();

            string expectedMessage = $"Water tank is filled with 20ml";

            FieldInfo waterTankLevelPrivateField = typeof(CoffeeMat)
               .GetField("waterTankLevel", BindingFlags.NonPublic | BindingFlags.Instance);

            int actualWaterTankLevelValue = (int)waterTankLevelPrivateField.GetValue(coffeeMat);
            int expectedWaterTankLevel = 20;

            Assert.AreEqual(expectedMessage, actualMessage);
            Assert.AreEqual(expectedWaterTankLevel, actualWaterTankLevelValue);
        }

        [Test]
        public void CoffeeMatFillWaterTankShouldReturnMessageIfCase()
        {
            coffeeMat = new CoffeeMat(0, 2);
            
            string actualMessage = coffeeMat.FillWaterTank();

            string expectedMessage = $"Water tank is already full!";

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void CoffeeMatAddDrinkShouldReturnTrueAndAddDrinkCorrectly()
        {
            bool isTrue = coffeeMat.AddDrink("Cola", 5);

            FieldInfo drinks = typeof(CoffeeMat)
                .GetField("drinks", BindingFlags.NonPublic | BindingFlags.Instance);

            Dictionary<string, double> actualDrinksDictionary = 
                (Dictionary<string, double>)drinks.GetValue(coffeeMat);

            var drink = actualDrinksDictionary.First();

            Assert.IsTrue(isTrue);
            Assert.AreEqual("Cola", drink.Key);
            Assert.AreEqual(5, drink.Value);
        }

        [Test]
        public void CoffeeMatAddDrinkShouldReturnFalse()
        {
            coffeeMat = new CoffeeMat(20, -1);
            
            bool isFalse = coffeeMat.AddDrink("Cola", 20);

            Assert.IsFalse(isFalse);
        }

        [Test]
        public void CoffeeMatBuyDrinkShouldReturnCorrectMessageIfWaterTankLevelIsLessThan80()
        {
            string actualMessage = coffeeMat.BuyDrink("Cola");

            string expectedMessage = $"CoffeeMat is out of water!";

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void CoffeeMatBuyDrinkShouldWorkProperly()
        {
            coffeeMat = new CoffeeMat(100, 1);
            string drinkName = "Cola";

            _ = coffeeMat.FillWaterTank();//water tank filled with 100 ml
            _ = coffeeMat.AddDrink(drinkName, 20);

            string actualMessage = coffeeMat.BuyDrink(drinkName);

            FieldInfo waterTankLevelPrivateField = typeof(CoffeeMat)
               .GetField("waterTankLevel", BindingFlags.NonPublic | BindingFlags.Instance);

            int actualWaterTankLevelValue = (int)waterTankLevelPrivateField.GetValue(coffeeMat);

            string expectedMessage = $"Your bill is {coffeeMat.Income:f2}$";

            Assert.AreEqual(20, actualWaterTankLevelValue);
            Assert.AreEqual(20, coffeeMat.Income);
            Assert.AreEqual(expectedMessage , actualMessage);
        }

        [Test]
        public void CoffeeMatBuyDrinkShouldReturnAnotherMessageProperly()
        {
            coffeeMat = new CoffeeMat(100, 1);
            
            coffeeMat.FillWaterTank();

            string actualMessage = coffeeMat.BuyDrink("Cola");
            
            string expectedMessage = $"Cola is not available!";

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void CoffeeMatCollectIncomeShouldWorkProperly()
        {
            double actualResult = coffeeMat.CollectIncome();

            Assert.AreEqual(0, actualResult);
            Assert.AreEqual(0, coffeeMat.Income);
        }

        [Test]
        public void CoffeeMatCollectIncomeShouldWorkWithAnotherCase()
        {
            coffeeMat = new CoffeeMat(100, 1);
            string drinkName = "Cola";

            _ = coffeeMat.FillWaterTank();//water tank filled with 100 ml
            _ = coffeeMat.AddDrink(drinkName, 20);
            _ = coffeeMat.BuyDrink(drinkName);

            double actualResult = coffeeMat.CollectIncome();
            double expectedResult = 20;

            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(0, coffeeMat.Income);
        }
    }
}