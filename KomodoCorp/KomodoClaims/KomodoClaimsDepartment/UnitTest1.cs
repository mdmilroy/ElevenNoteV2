using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoClaimsDepartment
{
    [TestClass]
    public class UnitTest1
    {
        ClaimsRepo repo = new ClaimsRepo();
        Claim claim1;
        Claim claim2;
        Claim claim3;
        Claim claim4;

        [TestInitialize]
        public void MyTestMethod()
        {
            claim1 = new Claim(1, "car", "highway crash, no fault", 5000, new DateTime(2020, 02, 01), new DateTime(2020, 02, 05), true);
            claim2 = new Claim(2, "house", "basement flooded", 500, new DateTime(2020, 01, 01), new DateTime(2020, 01, 30), true);
            claim3 = new Claim(3, "car", "hit parked car", 1000, new DateTime(2020, 03, 01), new DateTime(2020, 03, 15), false);
            claim4 = new Claim(4, "theft", "stolen wallet", 10, new DateTime(2019, 08, 01), new DateTime(2019, 09, 05), true);
        }

        [TestMethod]
        public void CreateNewClaimShouldAddClaimToList()
        {
            repo.CreateNewClaim(claim1);
            repo.CreateNewClaim(claim2);
            repo.CreateNewClaim(claim3);
            repo.CreateNewClaim(claim4);

            // Assert
            int expected = 4;
            int actual = repo.ViewAllClaims(repo._claims).Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HandleClaimShouldRemoveClaimFromList()
        {
            repo.CreateNewClaim(claim1);
            repo.CreateNewClaim(claim2);
            repo.CreateNewClaim(claim3);
            repo.CreateNewClaim(claim4);

            repo.HandleNextClaim(claim1);
            repo.HandleNextClaim(claim3);

            int expected1 = 2;
            int actual1 = repo.ViewAllClaims(repo._claims).Count();
            Assert.AreEqual(expected1, actual1);

            int expected2 = 2;
            int actual2 = repo.ViewHandledClaims(repo._claimsHandled).Count();
            Assert.AreEqual(expected2, actual2);
        }
    }
}