using DigiShop.CoreBussiness.EfCoreDomains.AccessPermissions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiShop.StorageService.EntityConfiguration
{
    public class PermissionConfiguration:IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.Property(prop => prop.permission).IsRequired().HasMaxLength(70);
        }
    }
}