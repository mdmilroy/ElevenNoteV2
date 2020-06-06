using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Freelancer
    {
        //public int FreelancerId { get; set; }
        public string FreelancerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Rating { get; set; } = 0;
        public string CodingLanguage { get; set; }
        public int JobsCompleted { get; set; } = 0;

        [Display(Name = "Join Date")]
        public DateTimeOffset CreatedUTC { get; set; }

        [Display(Name = "Last Updated")]
        public DateTimeOffset ModifiedUTC { get; set; }
    }
}
