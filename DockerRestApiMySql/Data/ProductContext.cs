using DockerRestApiMySql.Models;
using Microsoft.EntityFrameworkCore;

namespace DockerRestApiMySql.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) 
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
