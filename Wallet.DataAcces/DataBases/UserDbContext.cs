using Microsoft.EntityFrameworkCore;
using Wallet.Core.Entities;

namespace Wallet.Core.DataBases
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
            
        }
        public DbSet<UserEntity> Users { get; set; }
    }
}
