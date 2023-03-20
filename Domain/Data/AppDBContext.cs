using Domain.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
    }
}
