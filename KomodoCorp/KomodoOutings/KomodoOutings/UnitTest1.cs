using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoOutings
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddOutingShouldAddNewOutingToList()
        {
            // Arrange
            OutingsRepo repo = new OutingsRepo();
            Outings outing = new Outings(TypeOfEvent.Golf, 100, DateTime.Now, 50, 5000);

            // Act
            repo.AddOuting(outing);
            int expected = 1;

            // Assert
            int actual = repo.ListAllOutings().Count;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TotalCostShouldReturnTotalOfAllOutings()
        {
            // Arange
            OutingsRepo repo = new OutingsRepo();
            Outings outing1 = new Outings(TypeOfEvent.Golf, 50, DateTime.Now, 100, 5000);
            Outings outing2 = new Outings(TypeOfEvent.Golf, 50, DateTime.Now, 300, 15000);
            repo.AddOuting(outing1);
            repo.AddOuting(outing2);

            // Act
            double expected = 20000;
            double totalCost = repo.TotalOutingsCost();

            // Assert
            Assert.AreEqual(expected, totalCost);
        }

        [TestMethod]
        public void TotalCostByTypeShouldReturnTotalCostByGivenType()
        {
            // Arange
            OutingsRepo repo = new OutingsRepo();
            Outings outing1 = new Outings(TypeOfEvent.Golf, 50, DateTime.Now, 100, 5000);
            Outings outing2 = new Outings(TypeOfEvent.Bowling, 50, DateTime.Now, 300, 15000);
            Outings outing3 = new Outings(TypeOfEvent.Golf, 50, DateTime.Now, 100, 5000);
            repo.AddOuting(outing1);
            repo.AddOuting(outing2);
            repo.AddOuting(outing3);

            // Act
            double expectedGolf = 10000;
            double expectedBowling = 15000;
            double totalCostGolf = repo.TotalCostByType(TypeOfEvent.Golf);
            double totalCostBowling = repo.TotalCostByType(TypeOfEvent.Bowling);

            // Assert
            Assert.AreEqual(expectedGolf, totalCostGolf);
            Assert.AreEqual(expectedBowling, totalCostBowling);
        }
    }
}
