using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.JobPost
{
    public class JobPostList
    {
        public int JobPostId { get; set; }
        public string JobTitle { get; set; }
        public bool IsAwarded { get; set; } = false;
        //public int FreelancerId { get; set; }
    }
}
