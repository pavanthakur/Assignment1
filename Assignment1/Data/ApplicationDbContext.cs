using Microsoft.EntityFrameworkCore;

namespace Assignment1.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Order { get; set; }

        public DbSet<CookieBaking> CookieBaking { get; set; }

        public DbSet<CookiePacking> CookiePacking { get; set; }
    }
}
