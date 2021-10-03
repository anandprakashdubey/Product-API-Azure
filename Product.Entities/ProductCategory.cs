using Product.Entities.Interface;

namespace Product.Entities
{
    public class ProductCategory: IProductCategory
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDesc { get; set; }
    }
}
