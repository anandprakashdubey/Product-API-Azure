using Product.Context;
using Product.Entities.Interface;
using Product.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Repository
{
    public class ProductCategoryRepository: IProductCategoryRepository
    {
        private readonly DatabaseContext context;
        public ProductCategoryRepository(DatabaseContext _context)
        {
            context = _context;
        }

        public async Task<IProductCategory> CreateProductCategoryAsync(Product.Entities.ProductCategory productcategory)
        {
            await context.ProductCategories.AddAsync(productcategory);
            var id = await context.SaveChangesAsync();
            return productcategory;
        }
    }
}
