namespace Product.Entities.Interface
{
    public interface IProduct
    {
        int Id { get; set; }
        string Name { get; set; }
        int ProductCategoryId { get; set; }   

        ProductCategory ProductCategory { get; set; }
    }
}
