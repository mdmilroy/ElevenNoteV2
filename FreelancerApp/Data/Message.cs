using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Content { get; set; }
        public string SenderId { get; set; }
        public string Receiver { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset ModifiedUTC { get; set; }

        [ForeignKey("Employer")]
        public virtual Employer Employer { get; set; }

        [ForeignKey("Freelancer")]
        public virtual Freelancer Freelancer { get; set; }
    }
}
