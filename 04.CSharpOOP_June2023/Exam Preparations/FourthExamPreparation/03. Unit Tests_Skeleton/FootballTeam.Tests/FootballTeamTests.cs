using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace FootballTeam.Tests
{
    public class FootballTeamTests
    {
        private FootballTeam team;
        
        [SetUp]
        public void Setup()
        {
            team = new FootballTeam("Real Madrid", 50);
        }

        [Test]
        public void FootballTeamConstructorShouldInitializeCorrectly()
        {
            string expectedName = team.Name;
            int expectedCapacity = team.Capacity;

            Assert.AreEqual(expectedName, team.Name);
            Assert.AreEqual(expectedCapacity, team.Capacity);
            Assert.IsNotNull(team.Players);
        }

        [TestCase("", 30)]
        [TestCase(null, 40)]
        public void FootballTeamNameShouldThrowAnExceptionIfValueIsNullOrEmpty(string name, int capacity)
        {
           ArgumentException ex = Assert.Throws<ArgumentException>(() 
               => team = new FootballTeam(name, capacity));

            string expectedMessage = "Name cannot be null or empty!";

            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [Test]
        public void FootballTeamCapacityShouldThrowAnExceptionIfValueIsLessThan15()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() 
                => team = new FootballTeam("Barcelona", 14));

            string expectedMessage = "Capacity min value = 15";

            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [Test]
        public void FootballTeamNameSetterShouldWorkProperly()
        {
            string expectedName = "Levski";
           
            team.Name = expectedName;

            Assert.AreEqual(expectedName, team.Name);
        }

        [Test]
        public void FootballTeamCapacitySetterShouldWorkProperly()
        {
            int expectedCapacity = 45;

            team.Capacity = expectedCapacity;

            Assert.AreEqual(expectedCapacity, team.Capacity);
        }

        [Test]
        public void FootballTeamShouldAddNewPlayerCorrectly()
        {
            FootballPlayer expectedPlayer = new FootballPlayer("Ronaldo", 7, "Forward");

            string expectedMessage = team.AddNewPlayer(expectedPlayer);

            string actualMessage = $"Added player {expectedPlayer.Name} in position {expectedPlayer.Position} with number {expectedPlayer.PlayerNumber}";

            FootballPlayer actualPlayer = team.PickPlayer("Ronaldo");

            Assert.AreEqual(expectedMessage, actualMessage);
            Assert.AreEqual(expectedPlayer.Name, actualPlayer.Name);
            Assert.AreEqual(expectedPlayer.PlayerNumber, actualPlayer.PlayerNumber);
            Assert.AreEqual(expectedPlayer.Position, actualPlayer.Position);
            Assert.AreEqual(expectedPlayer.ScoredGoals, actualPlayer.ScoredGoals);
        }
       
        [Test]
        public void FootballTeamShouldNotAddNewPlayerIfCapacityIsEqualOrLessThanPlayersCount()
        {
            team = new FootballTeam("Liverpool", 15);

            for(int i = 0; i < 15; i++)
            {
                team.AddNewPlayer(new FootballPlayer("Ronaldo", 7, "Forward"));
            }
            
            string expectedMessaage = "No more positions available!";

            string actualMessage = team.AddNewPlayer(new FootballPlayer("Messi", 10, "Forward"));

            Assert.AreEqual(expectedMessaage, actualMessage);
        }

        [Test]
        public void FootballTeamShouldPickPlayerCorrectly()
        {
            FootballPlayer expectedPlayer = new FootballPlayer("Ronaldo", 7, "Forward");
            
            team.AddNewPlayer(expectedPlayer);

            FootballPlayer actualPlayer = team.PickPlayer("Ronaldo");

            Assert.AreEqual(expectedPlayer.Name, actualPlayer.Name);
            Assert.AreEqual(expectedPlayer.PlayerNumber, actualPlayer.PlayerNumber);
            Assert.AreEqual(expectedPlayer.Position, actualPlayer.Position);
            Assert.AreEqual(expectedPlayer.ScoredGoals, actualPlayer.ScoredGoals);
        }

        [Test]
        public void FootballTeamScoreMethodShouldWorkProperly()
        {
            FootballPlayer player = new FootballPlayer("Ronaldo", 7, "Forward");

            team.AddNewPlayer(player);

            string expectedMessage = $"{player.Name} scored and now has 1 for this season!";

            string actualMessage = team.PlayerScore(player.PlayerNumber);

            Assert.AreEqual(expectedMessage, actualMessage);
        }
    }
}
