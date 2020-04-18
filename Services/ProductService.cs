using API.Models;
using Contracts;
using Data.Entities;
using Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        public void CreateProduct(ProductCreateModel productToCreate)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(new Product(productToCreate));
                ctx.SaveChanges();
            }
        }
        public List<ProductListItem> GetProductList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx
                    .Products
                    .Select(product => new ProductListItem()
                {
                    Name = product.Name,
                    Price = product.Price
                })
                .ToList();
            }
        }
        public void UpdateProduct(ProductUpdateModel productToUpdate)
        {
            using (var ctx = new ApplicationDbContext())
            {
                // Find the product we want to update
                Product productWeWantToUpdate = ctx.Products.Find(productToUpdate.ProductID);

                if (productWeWantToUpdate != null)
                {
                // Update it
                productWeWantToUpdate.Name = productToUpdate.UpdatedName;
                productWeWantToUpdate.Price = productToUpdate.UpdatedPrice;
                // Save our changes to the database
                ctx.SaveChanges();
                }
            }
        }
    }
}
