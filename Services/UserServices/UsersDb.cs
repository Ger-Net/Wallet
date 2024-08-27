using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using Wallet22.MVVM.Commons;
using Wallet22.MVVM.Model;

namespace Wallet22.Services.UserServices
{
    public class UsersDb : DbContext
    {
        public DbSet<User> Users => Set<User>();

        public UsersDb()
        {
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={AppDomain.CurrentDomain.BaseDirectory}\\op.db");
        }
    }
}
