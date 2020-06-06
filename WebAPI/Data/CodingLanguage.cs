using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CodingLanguage : ICodingLanguage
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
