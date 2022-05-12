using DigiShop.CoreBussiness.EfCoreDomains.OTP;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiShop.StorageService.EntityConfiguration
{
    public class OtpConfiguration:IEntityTypeConfiguration<Otp>
    {
        public void Configure(EntityTypeBuilder<Otp> builder)
        {
            builder.Property(prop => prop.code).IsRequired().HasMaxLength(6);
            builder.HasOne(rel => rel.User).WithMany(child => child.Otps).HasForeignKey(k => k.userId);
        }
    }
}