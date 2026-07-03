using FreshMartPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace FreshMartPortal.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<StockItem> StockItems { get; set; }
        public DbSet<VendorProfile> VendorProfiles { get; set; }
        public DbSet<CheckoutRecord> CheckoutRecords { get; set; }
    }
}