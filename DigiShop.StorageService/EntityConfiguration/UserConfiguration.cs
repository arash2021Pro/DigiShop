using DigiShop.CoreBussiness.EfCoreDomains.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiShop.StorageService.EntityConfiguration
{
    public class UserConfiguration:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(prop => prop.Phonenumber).IsRequired().HasMaxLength(11);
            builder.Property(prop => prop.Password).IsRequired();
            builder.Property(prop => prop.NationalCode).IsRequired(false).HasMaxLength(10);
            builder.HasOne(rel => rel.Role).WithMany(child => child.Users).HasForeignKey(k => k.roleId);
        }
    }
}