using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Freelancer : IUser
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string CodingLanguage { get; set; }
        public int ProjectsCompleted { get; set; } = 0;
        public double Rating { get; set; } = 0.0;
        public bool AccountActive { get; set; } = true;
    }
}
