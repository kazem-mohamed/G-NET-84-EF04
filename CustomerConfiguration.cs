using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace G_NET_84_EF04;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(customer => customer.FullName).HasMaxLength(150).IsRequired();
        builder.Property(customer => customer.NationalId).HasMaxLength(30).IsRequired();
        builder.Property(customer => customer.Email).HasMaxLength(200).IsRequired();
        builder.Property(customer => customer.PhoneNumber).HasMaxLength(30).IsRequired();
        builder.Property(customer => customer.Address).HasMaxLength(300).IsRequired();
        builder.Property(customer => customer.CustomerType).HasConversion<string>().HasMaxLength(20);
        builder.HasIndex(customer => customer.NationalId).IsUnique();
    }
}
