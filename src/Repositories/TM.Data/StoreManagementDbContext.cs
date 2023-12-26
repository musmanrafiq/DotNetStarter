using Microsoft.EntityFrameworkCore;
using TM.Data.Models;

namespace TM.Data
{
    public class StoreManagementDbContext : DbContext
    {
        public StoreManagementDbContext(DbContextOptions<StoreManagementDbContext> options)
        : base(options)
        {
        }

        // all entities from database as dbsets
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}