using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactApi.Models.ModelConfiguration
{
    public class CustomerConfiguration: IEntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {

        }
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(c => c.BirthDay).HasMaxLength(20);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(500);

            builder.ToTable("Customers");
        }
    }
}