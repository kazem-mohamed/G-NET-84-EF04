using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace G_NET_84_EF04;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(account => account.AccountNumber);
        builder.Property(account => account.AccountNumber).HasMaxLength(30).IsRequired();
        builder.Property(account => account.CurrentBalance).HasPrecision(18, 2);
        builder.Property(account => account.AccountType).HasConversion<string>().HasMaxLength(20);
        builder.Property(account => account.BranchCode).HasMaxLength(20).IsRequired();
        builder.HasOne(account => account.Branch)
            .WithMany(branch => branch.Accounts)
            .HasForeignKey(account => account.BranchCode)
            .HasPrincipalKey(branch => branch.Code)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
