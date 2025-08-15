using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Wallet.Core.Configurations;
using Wallet.Persistence.Configurations;
using Wallet.Persistence.Entities;

namespace Wallet.Persistence.DataBases
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        
        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<OperationEntity> Operations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql(_configuration.GetConnectionString(nameof(AppDbContext)))
                .UseLoggerFactory(GetLoggerFactory())
                .EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new OperationsConfiguration());
        }
        private ILoggerFactory GetLoggerFactory()
        {
            return LoggerFactory.Create(builder => builder.AddConsole());
        }
    }
}
