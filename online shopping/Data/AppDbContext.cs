using Microsoft.EntityFrameworkCore;
using soft.Models;

namespace soft.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        public DbSet<userData> usersData { get; set; }
        public DbSet<Login> login { get; set; }
        public DbSet<Categories> Categories1 { get; set; }
        public DbSet<Deliveries> Deliveries1 { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ProductSold> ProductSolds { get; set; }
        public DbSet<ShoppingOrder> ShoppingOrders { get; set; }
        public DbSet<productVSshoppingorder> productVSshoppingorder1 { get; set; }
        public DbSet<products> products1 { get; set; }
        public DbSet<TransactionReports> TransactionReports1 { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
 