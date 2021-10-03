using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Entities.Interface;
using Product.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        public ProductController(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }

        /// <summary>
        /// Product API
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost("createproduct")]
        public async Task<IActionResult> CreateProduct(Product.Entities.Product product)
        {
            var data = await productRepository.CreateProductAsync(product);
            return Ok(new { Message = "Created" });        
        }


        [HttpGet("productlist")]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await productRepository.GetProductsAsync());
        }
    }
}
