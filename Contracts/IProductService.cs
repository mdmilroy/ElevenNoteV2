using Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IProductService
    {
        void CreateProduct(ProductCreateModel productToCreate);
        List<ProductListItem> GetProductList();
        void UpdateProduct(ProductUpdateModel productToUpdate);
    }
}
