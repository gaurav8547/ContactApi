using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactApi.Models.ModelConfiguration
{
    public class SupplierConfiguration: IEntityTypeConfiguration<Supplier>
    {

        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers");

            builder.Property(s => s.FirstName)
            .IsRequired()
            .HasMaxLength(1000);
            
            builder.Property(s => s.LastName)
            .IsRequired()
            .HasMaxLength(1000);
            
            builder.Property(s => s.Telephone)
                .IsRequired()
                .HasMaxLength(10);
        }
    }
}