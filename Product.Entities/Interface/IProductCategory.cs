namespace Product.Entities.Interface
{
    public interface IProductCategory
    {
        int Id { get; set; }
        string CategoryName { get; set; }
        string CategoryDesc { get; set; }
    }
}
