using DigiShop.CoreBussiness.EfCoreDomains.SiteSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiShop.StorageService.EntityConfiguration
{
    public class SiteSettingConfiguration:IEntityTypeConfiguration<SiteSetting>
    {
        public void Configure(EntityTypeBuilder<SiteSetting> builder)
        {
            builder.Property(prop => prop.EmailAddress).IsRequired(false);
            builder.Property(prop => prop.EmailPassword).IsRequired(false);
            builder.Property(prop => prop.SiteDescription).IsRequired(false);
            builder.Property(prop => prop.SiteKey).IsRequired(false);
            builder.Property(prop => prop.SiteName).IsRequired(false);
            builder.Property(prop => prop.SmsApi).IsRequired(false);
            builder.Property(prop => prop.SmsSender).IsRequired(false);
        }
    }
}