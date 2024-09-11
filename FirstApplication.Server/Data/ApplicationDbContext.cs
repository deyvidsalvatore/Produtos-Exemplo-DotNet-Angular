using FirstApplication.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace FirstApplication.Server.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options) {

        }

        public DbSet<Product> Products { get; set; }
    }
}
