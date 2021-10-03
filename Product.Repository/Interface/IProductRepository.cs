using Product.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Repository.Interface
{
    public interface IProductRepository
    {
        Task<IProduct> CreateProductAsync(Product.Entities.Product product);
        Task<IEnumerable<IProduct>> GetProductsAsync();
        Task<IEnumerable<IProduct>> GetProductByIdAsync(int id);
        Task<IEnumerable<IProduct>> GetProductByCategoryIdAsync(int id);
        Task DeleteProduct(int id);
    }
}
