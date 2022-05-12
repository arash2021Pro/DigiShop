using DigiShop.CoreBussiness.EfCoreDomains.StoreCategories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiShop.StorageService.EntityConfiguration
{
    public class StoreCategoryConfiguration:IEntityTypeConfiguration<StoreCategory>
    {
        public void Configure(EntityTypeBuilder<StoreCategory> builder)
        {
            builder.HasKey(k => k.id);
            builder.Property(prop => prop.ParentId).IsRequired(false);
        }
    }
}