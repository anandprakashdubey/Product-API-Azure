using Microsoft.EntityFrameworkCore;
using Product.Context;
using Product.Entities.Interface;
using Product.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext context;
        public ProductRepository(DatabaseContext _context)
        {
            context = _context;
        }

        public async Task<IProduct> CreateProductAsync(Product.Entities.Product product)
        {
            await context.Products.AddAsync(product);
            var id = await context.SaveChangesAsync();
            return product;
        }
        public async Task<IEnumerable<IProduct>> GetProductsAsync()
        {
            return await context.Products.Include(x => x.ProductCategory).ToListAsync();
        }
        public async Task<IEnumerable<IProduct>> GetProductByIdAsync(int id)
        {
            return await context.Products.Where(i => i.Id == id).ToListAsync();
        }
        public async Task<IEnumerable<IProduct>> GetProductByCategoryIdAsync(int id)
        {
            return await context.Products.Where(i => i.ProductCategoryId == id).Include(x => x.ProductCategory).ToListAsync();
        }
        public async Task DeleteProduct(int id)
        {
            var _product = await context.Products.Where(i => i.Id == id).FirstOrDefaultAsync();
            context.Products.Remove(_product);
            await context.SaveChangesAsync();
        }
    }
}
