using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wallet.Persistence.Entities;

namespace Wallet.Core.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.HasMany(x => x.Operations).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        }
    }
}
