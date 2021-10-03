using Product.Entities.Interface;
using System.Threading.Tasks;

namespace Product.Repository.Interface
{
    public interface IProductCategoryRepository
    {
        Task<IProductCategory> CreateProductCategoryAsync(Product.Entities.ProductCategory productCategory);
    }
}
