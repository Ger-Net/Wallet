using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet22.MVVM.Model;

namespace Wallet22.Services
{
    public class UserInAppDB : DbContext
    {
        public DbSet<Operation> Operations => Set<Operation>();
        public UserInAppDB()
        {
            Database.EnsureCreated();
            
        }
        public ObservableCollection<Operation> Load()
        {
            ObservableCollection<Operation> operations = [.. Operations];
            return operations;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={AppDomain.CurrentDomain.BaseDirectory}\\op.db");
            optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message));
        }
    }
}
