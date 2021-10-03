using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Entities;
using Product.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryRepository productCategoryRepository;
        public ProductCategoryController(IProductCategoryRepository _productCategoryRepository)
        {
            productCategoryRepository = _productCategoryRepository;
        }

        [HttpPost("createproductcategory")]
        public async Task<IActionResult> CreateProductCategory(ProductCategory productcategory)
        {
            var data = await productCategoryRepository.CreateProductCategoryAsync(productcategory);
            return Ok(new { Message = "Data" });
        }
    }
}
