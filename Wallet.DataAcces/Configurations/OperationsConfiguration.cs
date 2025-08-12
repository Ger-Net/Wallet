using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wallet.Core.Entities;

namespace Wallet.DataAccess.Configurations
{
    public class OperationsConfiguration : IEntityTypeConfiguration<OperationEntity>
    {
        public void Configure(EntityTypeBuilder<OperationEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Amount).IsRequired();
            builder.HasOne(x => x.User).WithMany(x => x.Operations).HasForeignKey(x => x.UserId);

        }
    }
}
