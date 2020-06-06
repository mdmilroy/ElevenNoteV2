using GoFreelance.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GoFreelance.WebAPI.Controllers
{
    public class FreelancerController : ApiController
    {
        List<Freelancer> freelancers = new List<Freelancer>();

        public FreelancerController()
        {
            freelancers.Add(new Freelancer { FirstName = "Michael", LastName = "Milroy", FreelancerId=1});
            freelancers.Add(new Freelancer { FirstName = "Mike", LastName = "Milroy", FreelancerId=2});
            freelancers.Add(new Freelancer { FirstName = "Mikey", LastName = "Milroy", FreelancerId=3});
        }

        // GET: api/Freelancer
        public List<Freelancer> Get()
        {
            return freelancers;
        }

        // GET: api/Freelancer/5
        public Freelancer Get(int id)
        {
            return freelancers.Where(f => f.FreelancerId == id).FirstOrDefault();
        }

        // POST: api/Freelancer
        public void Post(Freelancer person)
        {
            freelancers.Add(person);
        }

        // PUT: api/Freelancer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Freelancer/5
        public void Delete(int id)
        {
        }
    }
}
