using Microsoft.EntityFrameworkCore;
using NLog;
using System.Collections.ObjectModel;
using Wallet22.MVVM.Model;

namespace Wallet22.Services
{
    public class UserInAppDB : DbContext
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public DbSet<Operation> Operations => Set<Operation>();
        public UserInAppDB()
        {
            Database.EnsureCreated();

            _logger.Info("Data Base created");
        }
        public ObservableCollection<Operation> Load()
        {
            ObservableCollection<Operation> operations = [.. Operations];
            _logger.Info("collecting operations");

            return operations;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={AppDomain.CurrentDomain.BaseDirectory}\\op.db");
        }
    }
}
