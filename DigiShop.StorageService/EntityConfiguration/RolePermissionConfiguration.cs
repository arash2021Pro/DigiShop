using DigiShop.CoreBussiness.EfCoreDomains.AccessPermissions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiShop.StorageService.EntityConfiguration
{
    public class RolePermissionConfiguration:IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasOne(rel => rel.Role).WithMany(child => child.RolePermissions).HasForeignKey(k => k.roleId);
            builder.HasOne(rel => rel.Permission).WithMany(child => child.RolePermissions).HasForeignKey(k => k.permissionId);
        }
    }
}