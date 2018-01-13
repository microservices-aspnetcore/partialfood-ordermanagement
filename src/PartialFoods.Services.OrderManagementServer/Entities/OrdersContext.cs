using Microsoft.EntityFrameworkCore;

namespace PartialFoods.Services.OrderManagementServer.Entities
{
    public class OrdersContext : DbContext
    {
        private string connStr;

        public OrdersContext(string connectionString) : base()
        {
            connStr = connectionString;
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<LineItem> OrderItems { get; set; }

        public DbSet<OrderActivity> Activities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connStr);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Order>()
                .HasKey(o => o.OrderID);

            builder.Entity<LineItem>()
                .HasKey(li => new { li.OrderID, li.SKU });

            builder.Entity<OrderActivity>()
                .HasKey(a => new { a.OrderID, a.ActivityID });
        }
    }
}