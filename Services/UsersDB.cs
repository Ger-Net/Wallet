using Google.Cloud.Firestore.V1;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet22.MVVM.Model;

namespace Wallet22.Services
{
    public class UsersDB : DbContext
    {
        public DbSet<User> Operations => Set<User>();
        public UsersDB()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={AppDomain.CurrentDomain.BaseDirectory}\\users.db");
            
        }
    }
}
