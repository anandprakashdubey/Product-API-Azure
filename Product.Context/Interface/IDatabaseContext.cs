using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Product.Context.Interface
{
    public interface IDatabaseContext : IDisposable
    {
        DbSet<Product.Entities.Product> Products { get; set; }
        DbSet<Product.Entities.ProductCategory> ProductCategories { get; set; }         
    }
}
