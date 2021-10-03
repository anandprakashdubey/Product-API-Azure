using Product.Entities.Interface;

namespace Product.Entities
{
    public class Product: IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductCategoryId { get; set; }

        public ProductCategory ProductCategory { get; set; }
    }
}
