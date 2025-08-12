using Microsoft.EntityFrameworkCore;
using Wallet.Core.Entities;

namespace Wallet.Core.DataBases
{
    public class AppDbContext : DbContext
    {   
        public DbSet<UserEntity> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
