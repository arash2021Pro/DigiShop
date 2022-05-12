using DigiShop.CoreBussiness.EfCoreDomains.Stores;
using DigiShop.CoreBussiness.EfCoreDomains.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiShop.StorageService.EntityConfiguration
{
    public class StoreConfiguration:IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasKey(k => k.UserId);
            builder.HasOne<User>(r => r.User).WithOne(u => u.Store)
                .HasForeignKey<Store>(k => k.UserId);
            builder.Property(prop => prop.Mail).IsRequired();
            builder.Property(prop => prop.StoreName).IsRequired();
            builder.Property(prop => prop.Telephone).HasMaxLength(12).IsRequired(false);
            builder.Property(prop => prop.Address).IsRequired();
            builder.Property(prop => prop.Logo).IsRequired(false);
            builder.Property(prop => prop.Description).IsRequired(false);
        }
    }
}