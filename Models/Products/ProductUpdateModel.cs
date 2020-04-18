using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Products
{
    public class ProductUpdateModel
    {
        public int ProductID { get; set; }
        public decimal UpdatedPrice { get; set; }
        public string UpdatedName { get; set; }
    }
}
