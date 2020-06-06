using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Freelancer
{
    public class FreelancerCreate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CodingLanguage { get; set; }
        public int ProjectsCompleted { get; set; }
    }
}
