using Microsoft.EntityFrameworkCore;
using Product.Context.Interface; 
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Context
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }
        public DbSet<Product.Entities.Product> Products { get; set; }
        public DbSet<Product.Entities.ProductCategory> ProductCategories { get; set; }         
        
    }
}
