using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using Wallet22.MVVM.Model;

namespace Wallet22.Services
{
    public class UserDB: DbContext
    {
        public DbSet<Operation> Operations => Set<Operation>();
        public DbSet<User> Users => Set<User>();
        public UserDB()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public ObservableCollection<Operation> LoadOperations()
        {
            ObservableCollection<Operation> operations = [.. Operations];
            return operations;
        }
        public ObservableCollection<Operation> LoadOperations(User user)
        {
            ObservableCollection<Operation> op = [.. Users.Find(user).Operations];
            return op;
        }
        public void SaveUser(User user)
        {
            Users.Add(user);
            SaveChanges();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={AppDomain.CurrentDomain.BaseDirectory}\\users.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .HasMany(u => u.Operations)
                        .WithOne(o => o.User);

            modelBuilder.Entity<User>()
                        .HasMany(u => u.Friends)
                        .WithMany(u => u.Friends);


            modelBuilder.Entity<Operation>()
                .Property(o => o.Date)
                .HasConversion(
                    v => v.ToString("yyyy-MM-dd HH:mm:ss"),
                    v => DateTime.Parse(v));
        }
    }
}
