using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Tests.Services
{
    class FreelancerServiceTest
    {
        FreelancerService newService = new FreelancerService("1");

        [TestMethod]
        public void CreateFreelancerShouldAddNewFreelancerToTheFreelancerDB()
        {
        }

        [TestMethod]
        public void GetFreelancerShouldReturnAListOfFreelancersInTheFreelancerDB()
        {
        }

        [TestMethod]
        public void GetFreelancerByIdShouldReturnFullDetailsOfTheFreelancerInTheFreelancerDB()
        {
        }

        [TestMethod]
        public void UpdateFreelancerShouldEditTheFreelancerInTheFreelancerDB()
        {
        }

        [TestMethod]
        public void DeleteFreelancerShouldRemoveFreelancerFromTheFreelancerDB()
        {
        }
    }
}
