﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Message
{
    public class MessageDetail
    {
        public string Content { get; set; }
        public int EmployerId { get; set; }
        public int FreelancerId { get; set; }
        public bool IsRead { get; set; }
        public DateTimeOffset CreatedUTC { get; set; }
    }
}
