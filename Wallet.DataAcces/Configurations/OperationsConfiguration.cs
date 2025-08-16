using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wallet.Persistence.Entities;

namespace Wallet.Persistence.Configurations
{
    public class OperationsConfiguration : IEntityTypeConfiguration<OperationEntity>
    {
        public void Configure(EntityTypeBuilder<OperationEntity> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .IsRequired();

            builder
                .Property(x => x.Description)
                .IsRequired();

            builder
                .Property(x => x.Amount)
                .IsRequired();

            builder
                .Property(x => x.Type)
                .IsRequired();
        }
    }
}
