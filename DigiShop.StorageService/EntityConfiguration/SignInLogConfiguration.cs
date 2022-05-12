using DigiShop.CoreBussiness.EfCoreDomains.UserSignInlogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiShop.StorageService.EntityConfiguration
{
    public class SignInLogConfiguration:IEntityTypeConfiguration<SignInLog>
    {
        public void Configure(EntityTypeBuilder<SignInLog> builder)
        {
            builder.HasKey(prop => prop.id);
        }
    }
}