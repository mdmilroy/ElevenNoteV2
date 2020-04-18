using Contracts;
using Models.Products;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    //[Route("[controller]")]
    public class ProductController : ApiController
    {
        private IProductService _productService;
        
        // Create
        // product/create
        [HttpPost]
        public IHttpActionResult Create([FromBody] ProductCreateModel productToCreate)
        {
            _productService = new ProductService();

            _productService.CreateProduct(productToCreate);

            return Ok();
        }
        // Read List
        // product/list
        [HttpGet]
        public IHttpActionResult List()
        {
            _productService = new ProductService();

            return Ok(_productService.GetProductList());
        }
        // Read Detail
        // product/detail
        // Implemented this

        // Update
        // product/update
        [HttpPut]
        public IHttpActionResult Update([FromBody] ProductUpdateModel productToUpdate)
        {
            if (ModelState.IsValid)
            {
            _productService = new ProductService();

            _productService.UpdateProduct(productToUpdate);

            return Ok();
            }
            return BadRequest("Invalid model state");
        }

    }
}
