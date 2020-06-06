using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoBadges
{
    [TestClass]
    public class UnitTest1
    {
        // TODO initialize new badge, repo, and lists here
        BadgesRepo _badges = new BadgesRepo();
        Badges newBadge = new Badges();
        List<string> _accessDoors = new List<string>();
        

        [TestInitialize]
        public void MyTestMethod()
        {
            _accessDoors.Add("A4");
            _accessDoors.Add("B1");
            _accessDoors.Add("C6");
            _accessDoors.Add("C7");
        }

        [TestMethod]
        public void CreateShouldAddItem()
        {
            // Arrange
            newBadge.badgeAccess = _accessDoors;

            // Act
            _badges.CreateBadge(newBadge);


            // Assert
            int expected = 1;
            int actual = _badges.ViewAllBadges(_badges._allBadges).Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EditBadgesShouldChangeBadgeInfo()
        {
            // Arrange
            newBadge.badgeAccess = _accessDoors;

            // Act
            newBadge.badgeAccess.Remove("B1");

            // Assert
            Assert.AreEqual(3, newBadge.badgeAccess.Count);

        }

    }
}
