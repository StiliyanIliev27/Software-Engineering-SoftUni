using NUnit.Framework;
using System;

namespace FootballTeam.Tests
{
    public class FootballPlayerTests
    {
        [TestCase("gosho", 10, "Goalkeeper")]
        [TestCase("mladen", 6, "Midfielder")]
        [TestCase("peter", 10, "Forward")]
        public void FootballPlayerConstructorShouldInitializeCorrectly(string name, int number, string position)
        {
            FootballPlayer fp = new FootballPlayer(name, number, position);

            string expectedName = fp.Name;
            int expectedNumber = fp.PlayerNumber;
            string expectedPosition = fp.Position;

            Assert.AreEqual(expectedName, fp.Name);
            Assert.AreEqual(expectedNumber, fp.PlayerNumber);
            Assert.AreEqual(expectedPosition, fp.Position);
            Assert.AreEqual(0, fp.ScoredGoals);
        }

        [TestCase("", 10, "Goalkeeper")]
        [TestCase(null, 6, "Midfielder")]
        public void FootballPlayerNameShouldThrowAnExceptionIfValueIsNullOrEmpty(string name, int number, string position)
        {
            string expectedMessage = "Name cannot be null or empty!";
           
            ArgumentException ex = Assert.Throws<ArgumentException>(()
                => new FootballPlayer(name, number, position));

            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [TestCase("gosho", 0, "Goalkeeper")]
        [TestCase("petio", 22, "Midfielder")]
        public void FootballPlayerNumberShouldThrowAnExceptionIfValueIsLessThanOneOrGreaterThan21(string name, int number, string position)
        {
            string expectedMessage = "Player number must be in range [1,21]";

            ArgumentException ex = Assert.Throws<ArgumentException>(()
                => new FootballPlayer(name, number, position));

            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [TestCase("gosho", 7, "LW")]
        [TestCase("petio", 12, "RW")]
        public void FootballPlayerPositionShouldThrowAnExceptionIfValueIsIncorrect(string name, int number, string position)
        {
            string expectedMessage = "Invalid Position";

            ArgumentException ex = Assert.Throws<ArgumentException>(()
                => new FootballPlayer(name, number, position));

            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [Test]
        public void FootballPlayerScoreShouldIncreaseScoredGoals()
        {
            FootballPlayer fp = new FootballPlayer("petko", 20, "Forward");

            fp.Score();

            Assert.AreEqual(1, fp.ScoredGoals);
        }
    }
}