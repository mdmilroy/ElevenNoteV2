using Models.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Product
    {
        public Product(ProductCreateModel productToCreate)
        {
            Name = productToCreate.Name;
            Price = productToCreate.Price;
            CreatedAt = DateTime.Now;
        }
        public Product() { }
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
