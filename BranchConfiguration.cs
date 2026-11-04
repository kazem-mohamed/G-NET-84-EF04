using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace G_NET_84_EF04;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.HasKey(branch => branch.Code);
        builder.Property(branch => branch.Code).HasMaxLength(20).IsRequired();
        builder.Property(branch => branch.Name).HasMaxLength(150).IsRequired();
        builder.Property(branch => branch.Address).HasMaxLength(300).IsRequired();
        builder.Property(branch => branch.PhoneNumber).HasMaxLength(30).IsRequired();
    }
}
