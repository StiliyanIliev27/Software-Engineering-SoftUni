namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;
        
        [SetUp]
        public void Setup()
        {
            database = new Database(1, 2);
        }
        
        [Test]
        public void CreatingDataBaseShouldHaveCorrectCount()
        {
            int expectedResult = 2;

            int actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 10, 11, 12, 13, 14, 15, 16 })]
        public void CreatingDataBaseShouldAddElementsCorrectly(int[] data)
        {
            database = new(data);
            int[] actualResult = database.Fetch();

            Assert.AreEqual(data, actualResult);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 })]
        public void CreatingDataBaseShouldThrowAnExceptionIfCountIsMoreThan16(int[] data)
        {           
            InvalidOperationException exception = 
                Assert.Throws<InvalidOperationException>(() => database = new Database(data));
         
            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }
       
        [Test]
        public void DataBaseCountShouldWorkCorrectly()
        {
            int expectedResult = 2;

            int actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }
       
        [Test]
        public void DataBaseAddShouldIncreaseCount()
        {
            int expectedResult = 3;

            database.Add(1);

            Assert.AreEqual(expectedResult, database.Count);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        public void DataBaseAddShouldAddNumbersCorrectly(int[] numbers)
        {
            database = new Database();

            foreach(var number in numbers)
            {
                database.Add(number);
            }

            int[] actualResult = database.Fetch();

            Assert.AreEqual(numbers, actualResult);
        }

        [Test]
        public void DataBaseAddShouldThrowAnExceptionIfCountIsMoreThan16()
        {
            for(int i = 0; i < 14; i++)
            {
                database.Add(i);
            }
            
            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => database.Add(1));

            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }

        [Test]       
        public void DataBaseRemoveShouldDecreaseCountCorrectly()
        {
            int expectedResult = 1;

            database.Remove();

            Assert.AreEqual(expectedResult, database.Count);
        }
        
        [Test]
        public void DataBaseRemoveShouldRemoveCorrectly()
        {
            int[] expectedResult = Array.Empty<int>();

            database.Remove();
            database.Remove();

            int[] actualResult = database.Fetch();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void DataBaseRemoveShouldThrownAnExceptionIfCountIsZero()
        {
            database.Remove();
            database.Remove();

            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => database.Remove());

            Assert.AreEqual("The collection is empty!", exception.Message);
        }

        [TestCase(new int[] {1, 2, 3, 4, 5})]
        public void DataBaseFetchShouldWorkCorrectly(int[] data)
        {
            database = new Database(data);

            int[] actualResult = database.Fetch();

            Assert.AreEqual(data, actualResult);
        }
    }
}
