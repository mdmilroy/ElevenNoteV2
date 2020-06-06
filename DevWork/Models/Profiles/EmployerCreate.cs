﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Profiles
{
    public class EmployerCreate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Organization { get; set; }
        public DateTimeOffset CreatedUTC { get; set; }
    }
}
