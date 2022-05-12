using DigiShop.CoreBussiness.EfCoreDomains.AccessPermissions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiShop.StorageService.EntityConfiguration
{
    public class RoleConfiguration:IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(prop => prop.rolename).IsRequired().HasMaxLength(70);
        }
    }
}