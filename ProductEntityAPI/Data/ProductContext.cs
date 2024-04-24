using Microsoft.EntityFrameworkCore;
using ProductEntityAPI.Models;

namespace ProductEntityAPI.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        public DbSet<ProductEntity> products { get; set; }
    }
}
