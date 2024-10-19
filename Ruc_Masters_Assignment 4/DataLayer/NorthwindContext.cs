using Microsoft.EntityFrameworkCore;

namespace CITS_asgmt_4.DataLayer
{
    internal class NorthwindContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(); //for debug in dev mode;
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            optionsBuilder.UseNpgsql("host = localhost; db=nw; uid=postgres; pwd=postgres");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}