using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class WarehouseManagementContext : DbContext
    {

        public WarehouseManagementContext() { }
        public WarehouseManagementContext(DbContextOptions<WarehouseManagementContext> options)
            : base(options)
         {
    
         }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=;database=warehousedb",
                    ServerVersion.AutoDetect("server=localhost;port=3306;user=root;password=;database=warehousedb"));
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Warehouse> warehouses { get; set; }
        public DbSet<Stock> Stocks { get; set; }

    }
}
