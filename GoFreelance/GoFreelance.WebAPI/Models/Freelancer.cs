using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoFreelance.WebAPI.Models
{
    public class Freelancer
    {
        public int FreelancerId { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
    }
}