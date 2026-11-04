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

        builder.HasData(
            new Branch { Code = "CAI-01", Name = "Cairo Main Branch", Address = "Nile Street, Cairo", PhoneNumber = "01000000001" },
            new Branch { Code = "ALX-01", Name = "Alexandria Branch", Address = "Corniche Road, Alexandria", PhoneNumber = "01000000002" });
    }
}
