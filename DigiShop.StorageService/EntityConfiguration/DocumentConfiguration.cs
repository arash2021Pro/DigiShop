using DigiShop.CoreBussiness.EfCoreDomains.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiShop.StorageService.EntityConfiguration
{
    public class DocumentConfiguration:IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.Property(prop => prop.NationalCode).HasMaxLength(10).IsRequired(false);
            builder.Property(prop => prop.Homephone).IsRequired(false);
            builder.Property(prop => prop.Address).IsRequired(false).HasMaxLength(250);
            builder.Property(prop => prop.AccountOwner).IsRequired(false);
            builder.Property(prop => prop.BankName).IsRequired(false);
            builder.Property(prop => prop.CardNumber).IsRequired(false);
            builder.Property(prop => prop.ShabaCode).IsRequired(false);
            builder.HasOne(rel => rel.User).WithMany(item => item.Documents).HasForeignKey(k => k.userId);
        }
    }
}