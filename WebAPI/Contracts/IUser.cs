using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUser
    {
        string Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string FullName { get; set; }
        int ProjectsCompleted { get; set; }
        bool AccountActive { get; set; }

        [Max(5.0)]
        double Rating { get; set; }
    }
}
