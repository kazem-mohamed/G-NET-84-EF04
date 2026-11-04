using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace G_NET_84_EF04;

public class CustomerAccountConfiguration : IEntityTypeConfiguration<CustomerAccount>
{
    public void Configure(EntityTypeBuilder<CustomerAccount> builder)
    {
        builder.HasKey(link => new { link.AccountNumber, link.CustomerId });
        builder.Property(link => link.AccountNumber).HasMaxLength(30).IsRequired();
        builder.Property(link => link.OwnershipType).HasConversion<string>().HasMaxLength(20);
        builder.Property(link => link.AccountStatus).HasConversion<string>().HasMaxLength(20);
        builder.HasOne(link => link.Account).WithMany(account => account.CustomerAccounts)
            .HasForeignKey(link => link.AccountNumber).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(link => link.Customer).WithMany(customer => customer.CustomerAccounts)
            .HasForeignKey(link => link.CustomerId).OnDelete(DeleteBehavior.Cascade);
    }
}
