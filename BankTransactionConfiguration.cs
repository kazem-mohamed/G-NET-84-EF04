using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace G_NET_84_EF04;

public class BankTransactionConfiguration : IEntityTypeConfiguration<BankTransaction>
{
    public void Configure(EntityTypeBuilder<BankTransaction> builder)
    {
        builder.HasKey(transaction => transaction.TransactionNumber);
        builder.Property(transaction => transaction.TransactionNumber).HasMaxLength(40).IsRequired();
        builder.Property(transaction => transaction.Amount).HasPrecision(18, 2);
        builder.Property(transaction => transaction.TransactionType).HasConversion<string>().HasMaxLength(20);
        builder.Property(transaction => transaction.Note).HasMaxLength(500);
        builder.Property(transaction => transaction.AccountNumber).HasMaxLength(30).IsRequired();
        builder.HasOne(transaction => transaction.Account).WithMany(account => account.Transactions)
            .HasForeignKey(transaction => transaction.AccountNumber).OnDelete(DeleteBehavior.Cascade);
    }
}
